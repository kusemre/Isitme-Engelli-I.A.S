package com.example.emku.ilacanlatimsistemi;

import android.app.SearchManager;
import android.content.Intent;
import android.os.StrictMode;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;
import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;

public class islem_yap extends AppCompatActivity implements View.OnClickListener {
    ServiceManager serviceManager;
    ImageView ilac_tara;
    ImageView eczane;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_islem_yap);

        StrictMode.ThreadPolicy policy = new StrictMode.ThreadPolicy.Builder().permitAll().build();
        StrictMode.setThreadPolicy(policy);

        ilac_tara = (ImageView)findViewById(R.id.img_ilac_tara);
        eczane = (ImageView)findViewById(R.id.img_eczane) ;

        eczane.setOnClickListener(this);
        ilac_tara.setOnClickListener(this);
    }

    @Override
    public void onClick(View view) {
        Intent in = null;
        switch (view.getId())
        {
            case R.id.img_ilac_tara:
                try {
                    IntentIntegrator integrator = new IntentIntegrator(islem_yap.this);
                    integrator.setDesiredBarcodeFormats(IntentIntegrator.DATA_MATRIX_TYPES);
                    integrator.setPrompt("QR KOD TARANIYOR");
                    integrator.setCameraId(0);
                    integrator.setBeepEnabled(true);
                    integrator.setCaptureActivity(tara.class);
                    integrator.setOrientationLocked(false);
                    integrator.setBarcodeImageEnabled(false);
                    integrator.initiateScan();
                }
                catch (Exception ex)  {
                    Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
                }
                break;

            case R.id.img_eczane:
                in = new Intent(Intent.ACTION_WEB_SEARCH);
                in.putExtra(SearchManager.QUERY,"nöbetçi eczaneler");
                startActivity(in);
                break;
        }
    }
    void ilac_sorgula(String qr_kod)
    {

        try {
            serviceManager=new ServiceManager();
            String[] gelen_veriler = serviceManager.ilac_getir(qr_kod);
            if(!qr_kod.equals("")) {
                if (gelen_veriler.length > 2) {
                    Intent in_ilac_tanit = new Intent(islem_yap.this, ilactanit.class);
                    in_ilac_tanit.putExtra("ilac_adi", gelen_veriler[1]);
                    in_ilac_tanit.putExtra("ilac_turu", gelen_veriler[2]);
                    in_ilac_tanit.putExtra("ilac_kul_tal", gelen_veriler[3]);
                    in_ilac_tanit.putExtra("ilac_url", gelen_veriler[4]);
                    startActivity(in_ilac_tanit);
                } else
                    Toast.makeText(this, "Kayıt Bulunamadı... ", Toast.LENGTH_SHORT).show();
            }
        }
        catch (Exception ex) {
            AlertDialog.Builder ald = new AlertDialog.Builder(islem_yap.this);
            ald.setMessage("Hata! -> Sunucu aktif değil. \n İçerik:"+ ex.toString());
            ald.show();
        }

    }
    protected void onActivityResult(int requestCode, int resultCode, Intent data) {

        try {
            IntentResult result = IntentIntegrator.parseActivityResult(requestCode, resultCode, data);
            if (result != null) {
                if (result.getContents() == null) {
                    Toast.makeText(this, "Tarama işlemi iptal edildi...", Toast.LENGTH_LONG).show();
                } else {
                    String gelen = result.getContents().toString().trim();

                    String topla = "";

                    for (int j = 0; j < gelen.length() - 1; j++) {
                        char karakter = gelen.charAt(j);
                        int i = (int) karakter;
                        if (i != 29)
                            topla = topla + gelen.charAt(j);
                    }
                    ilac_sorgula(topla);

                }

            } else {
                super.onActivityResult(requestCode, resultCode, data);
            }
        }
        catch (Exception ex) { Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show(); }
    }

}