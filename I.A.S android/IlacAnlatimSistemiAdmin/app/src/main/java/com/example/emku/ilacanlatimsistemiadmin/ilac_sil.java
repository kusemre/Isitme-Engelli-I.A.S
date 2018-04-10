package com.example.emku.ilacanlatimsistemiadmin;

import android.app.ProgressDialog;
import android.content.Intent;
import android.os.AsyncTask;
import android.os.StrictMode;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ArrayAdapter;
import android.widget.Button;
import android.widget.TextView;
import android.widget.Toast;

public class ilac_sil extends AppCompatActivity {

    ProgressDialog barProgressDialog;
    Bundle gelen_veriler;
    ServiceManager serviceManager;
    TextView tv_ilac_adi;
    TextView tv_ilac_turu;
    TextView tv_ilac_kullan_tal;
    TextView tv_ilac_url;
    String qr_kod;
    int ilac_id = -1;
    String ilac_adi = "";
    String ilac_turu = "";
    String ilac_kul_tal = "";
    String ilac_url = "";
    Button btn_ilac_sil;

    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ilac_sil);

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);
        gelen_veriler = getIntent().getExtras();

        ilac_id = Integer.parseInt(gelen_veriler.get("ilac_id").toString());
        ilac_adi = gelen_veriler.get("ilac_adi").toString();
        ilac_turu = gelen_veriler.get("ilac_turu").toString();
        ilac_kul_tal = gelen_veriler.get("ilac_kul_tal").toString();
        qr_kod = gelen_veriler.get("qr_kod").toString();
        ilac_url = gelen_veriler.get("ilac_url").toString();


        tv_ilac_adi = (TextView) findViewById(R.id.textView_ilac_adi);
        tv_ilac_turu = (TextView) findViewById(R.id.textView_ilac_turu);
        tv_ilac_kullan_tal = (TextView) findViewById(R.id.textView_ilac_kullanimi);
        tv_ilac_url = (TextView) findViewById(R.id.textView_url);

        tv_ilac_adi.setText(ilac_adi);
        tv_ilac_turu.setText(ilac_turu);
        tv_ilac_kullan_tal.setText(ilac_kul_tal);
        tv_ilac_url.setText(ilac_url);

        btn_ilac_sil = (Button)findViewById(R.id.btn_sil);
        btn_ilac_sil.setOnClickListener(new View.OnClickListener() {
            @Override
            public void onClick(View view) {
                try {
                    serviceManager = new ServiceManager();
                    String response = serviceManager.ilac_sil(ilac_id);
                    Toast.makeText(ilac_sil.this, response, Toast.LENGTH_SHORT).show();
                    if (response.equals("true")) {
                        Toast.makeText(ilac_sil.this, "İlgili ilaç silindi.", Toast.LENGTH_SHORT).show();
                        Intent anasayfa = new Intent(ilac_sil.this, islem_yap.class);
                        startActivity(anasayfa);
                        finish();
                    }
                }
                catch (Exception ex) {
                    Toast.makeText(ilac_sil.this,"Sunucu hatası->"+ ex.toString(), Toast.LENGTH_SHORT).show();
                }
            }
        });


        barProgressDialog = new ProgressDialog(ilac_sil.this);
        barProgressDialog.setMessage("Lütfen bekleyiniz ...");
        barProgressDialog.setProgressStyle(ProgressDialog.STYLE_SPINNER);
        barProgressDialog.setCanceledOnTouchOutside(false);
        barProgressDialog.setCancelable(false);

    }

}
