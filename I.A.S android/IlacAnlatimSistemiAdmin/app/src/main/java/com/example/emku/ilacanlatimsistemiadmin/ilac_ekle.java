package com.example.emku.ilacanlatimsistemiadmin;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.os.SystemClock;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.AdapterView;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.EditText;
import android.widget.Spinner;
import android.widget.Toast;

public class ilac_ekle extends AppCompatActivity implements View.OnClickListener,AdapterView.OnItemSelectedListener {
    Bundle gelen_veriler;
    EditText edt_ilac_adi;
    Spinner spn_ilac_turu;
    EditText edt_ilac_kulllanimi;
    EditText edt_ilac_url;
    Button btn_kaydet;
    String[] gelen_ilac_turleri = { "Veri bulunamadı..."};
    ServiceManager serviceManager;
    int ilac_secim_indis = -1;
    String qr_kod="";
    int[] ilac_turleri_indis;
    ProgressDialog barProgressDialog;
    ArrayAdapter<String> ilac_turu_adapter;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ilac_ekle);


        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        try {
            gelen_veriler = getIntent().getExtras();
            qr_kod = gelen_veriler.get("qr_kod").toString();

            barProgressDialog = new ProgressDialog(ilac_ekle.this);
            barProgressDialog.setMessage("Lütfen bekleyiniz ...");
            barProgressDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
            barProgressDialog.setCanceledOnTouchOutside(false);
            barProgressDialog.setCancelable(false);

            spn_ilac_turu = (Spinner) findViewById(R.id.spinner_ilac_turu);
            spn_ilac_turu.setOnItemSelectedListener(this);

            edt_ilac_adi = (EditText) findViewById(R.id.editText_ilac_adi);
            edt_ilac_kulllanimi = (EditText) findViewById(R.id.editText_ilac_kullanimi);
            edt_ilac_url = (EditText) findViewById(R.id.editText_url);

            btn_kaydet = (Button) findViewById(R.id.btn_kaydet);
            btn_kaydet.setOnClickListener(this);

            new MyTask().execute();
        }
        catch (Exception ex) {
            Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    public void onClick(View view) {

        switch (view.getId())
        {
            case R.id.btn_kaydet:
                try {
                    if(!edt_ilac_adi.getText().toString().trim().equals("") && ilac_secim_indis != -1 && !edt_ilac_kulllanimi.getText().toString().trim().equals("") && !edt_ilac_url.getText().toString().trim().equals("")  ) {
                        String donus = serviceManager.ilac_kaydet(edt_ilac_adi.getText().toString(), ilac_secim_indis, edt_ilac_kulllanimi.getText().toString(), qr_kod, edt_ilac_url.getText().toString());
                        Toast.makeText(this, donus, Toast.LENGTH_SHORT).show();
                        Intent anasayfa = new Intent(ilac_ekle.this,islem_yap.class);
                        startActivity(anasayfa);
                        finish();
                    }
                    else
                        Toast.makeText(this, "Lütfen ilgili alanları doldurunuz...", Toast.LENGTH_SHORT).show();
                }
                catch (Exception ex)  {
                    Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
                break;
        }
    }

    @Override
    public void onItemSelected(AdapterView<?> adapterView, View view, int i, long l) {
        ilac_secim_indis = ilac_turleri_indis[i];
    }

    @Override
    public void onNothingSelected(AdapterView<?> adapterView) {

    }
    class MyTask extends AsyncTask<Integer, Integer, String> {
        @Override
        public String doInBackground(Integer... params) {  //Arkaplanda yapılan işlem

            try {
                serviceManager = new ServiceManager();
                gelen_ilac_turleri = serviceManager.ilac_turu_getir();
                ilac_turleri_indis = new int[gelen_ilac_turleri.length/2];
                String[] ilac_turleri = new String[gelen_ilac_turleri.length/2];
                int sayac=0;

                for(int i = 0; i < gelen_ilac_turleri.length; i = i + 2) {
                    ilac_turleri_indis[sayac] = Integer.parseInt(gelen_ilac_turleri[i]);
                    sayac++;
                }
                sayac=0;
                for(int i = 1; i < gelen_ilac_turleri.length; i = i + 2) {
                    ilac_turleri[sayac] = gelen_ilac_turleri[i].toString();
                    sayac++;
                }

                ilac_turu_adapter = new ArrayAdapter<String>(ilac_ekle.this,R.layout.layout_ilac_tur_spin,R.id.textView_ilac_tur_spin,ilac_turleri);
                return "true";
            } catch (Exception e) {
                barProgressDialog.dismiss();
                e.printStackTrace();
                return "false";
            }

        }
        @Override
        protected void onPostExecute(String result) { // Uyuma bittikten sonra yapılacak işlem
            if(result.equals("true")) {
                barProgressDialog.dismiss();
                spn_ilac_turu.setAdapter(ilac_turu_adapter);
            }
            else {
                Toast.makeText(getApplicationContext(), "sunucuyu kontrol ediniz...", Toast.LENGTH_SHORT).show();
                Intent anasayfa = new Intent(ilac_ekle.this,islem_yap.class);
                startActivity(anasayfa);
                finish();
            }
        }
        @Override
        protected void onPreExecute() {     // Uyurken önplanda tutulan işlem
            barProgressDialog.show();

        }
    }
}
