package com.example.emku.ilacanlatimsistemiadmin;

import android.content.Intent;
import android.support.v7.app.AlertDialog;
import android.support.v7.app.AppCompatActivity;
import android.os.Bundle;
import android.view.View;
import android.widget.ImageView;
import android.widget.Toast;

import com.google.zxing.integration.android.IntentIntegrator;
import com.google.zxing.integration.android.IntentResult;
import com.journeyapps.barcodescanner.CaptureActivity;

public class islem_yap extends AppCompatActivity implements View.OnClickListener {
    ServiceManager serviceManager;
    String qr_kod = "";
    ImageView tara;
    ImageView img_ilac_ekle;
    ImageView img_ilac_sil;
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_islem_yap);

        tara = (ImageView)findViewById(R.id.img_ilac_tara);
        tara.setOnClickListener(this);

        img_ilac_ekle = (ImageView)findViewById(R.id.img_ilac_ekle);
        img_ilac_ekle.setOnClickListener(this);

        img_ilac_sil = (ImageView)findViewById(R.id.img_ilac_sil);
        img_ilac_sil.setOnClickListener(this);


    }

    @Override
    public void onClick(View view) {
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
            case R.id.img_ilac_ekle:
               if(!qr_kod.equals("")) {
                    Intent in_ilac_ekle = new Intent(this, ilac_ekle.class);
                    in_ilac_ekle.putExtra("qr_kod", qr_kod);
                    startActivity(in_ilac_ekle);
                    finish();
                }
                else
                    Toast.makeText(this, "Lütfen ilgili ilacı tarayınız...!", Toast.LENGTH_SHORT).show();
                break;
            case R.id.img_ilac_sil:
                if(!qr_kod.equals("")) {
                    serviceManager = new ServiceManager();
                    String[] gelen_veriler1 = serviceManager.ilac_getir(qr_kod);
                    String gelen1 = String.valueOf(gelen_veriler1[0].toString());
                    Toast.makeText(this, qr_kod, Toast.LENGTH_SHORT).show();

          ;
                    if (gelen_veriler1.length > 2) {
                        Intent in_ilac_sil = new Intent(this, ilac_sil.class);
                        in_ilac_sil.putExtra("qr_kod", qr_kod);
                        in_ilac_sil.putExtra("ilac_id", gelen_veriler1[0]);
                        in_ilac_sil.putExtra("ilac_adi", gelen_veriler1[1]);
                        in_ilac_sil.putExtra("ilac_turu", gelen_veriler1[2]);
                        in_ilac_sil.putExtra("ilac_kul_tal", gelen_veriler1[3]);
                        in_ilac_sil.putExtra("ilac_url", gelen_veriler1[4]);
                        startActivity(in_ilac_sil);
                        finish();
                    }
                    else
                        Toast.makeText(this, "Bu ilaç mevcut değil...!", Toast.LENGTH_SHORT).show();
                }
                else
                    Toast.makeText(this, "Lütfen ilgili ilacı tarayınız...!", Toast.LENGTH_SHORT).show();
                break;

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
                    qr_kod = topla;
                    Toast.makeText(this, "İlaç ekleme veya silme işlemine geçebilirsiniz...", Toast.LENGTH_SHORT).show();

                }

            } else {
                super.onActivityResult(requestCode, resultCode, data);
            }
        }
        catch (Exception ex) { Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show(); }
    }

}
