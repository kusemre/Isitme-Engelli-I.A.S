package com.example.emku.ilacanlatimsistemi;

import android.content.Intent;
import android.os.Bundle;
import android.widget.TextView;
import android.widget.Toast;
import com.google.android.youtube.player.YouTubeBaseActivity;
import com.google.android.youtube.player.YouTubeInitializationResult;
import com.google.android.youtube.player.YouTubePlayer;
import com.google.android.youtube.player.YouTubePlayerView;

public class ilactanit extends YouTubeBaseActivity implements YouTubePlayer.OnInitializedListener  {
    // OnInitializedListenerr     -> Başlatmada hata olup olmadığını dinlemek için implements ettik
    private static final int RECOVERY_REQUEST = 1;
    public static final String YOUTUBE_API_KEY = "AIzaSyBWLnqi7RIaF30KOJbHlADbTSgRTlgGdrc";
    private YouTubePlayerView youTubeView;
    Bundle aktarilan_veriler;

    TextView tw_ilac_adi;
    TextView tw_ilac_turu;
    TextView tw_ilac_kul_tal;
    String ilac_adi = "";
    String ilac_turu = "";
    String ilac_kul_tal = "";
    String ilac_url = "";
    @Override
    protected void onCreate(Bundle savedInstanceState) {
        super.onCreate(savedInstanceState);
        setContentView(R.layout.activity_ilactanit);

        aktarilan_veriler = getIntent().getExtras();
        ilac_adi =  aktarilan_veriler.get("ilac_adi").toString();
        ilac_turu =  aktarilan_veriler.get("ilac_turu").toString();
        ilac_kul_tal =  aktarilan_veriler.get("ilac_kul_tal").toString();
        ilac_url =  aktarilan_veriler.get("ilac_url").toString();
        tw_ilac_adi = (TextView)findViewById(R.id.textView_icerik_ilac_adi);
        tw_ilac_turu = (TextView)findViewById(R.id.textView_icerik_ilac_turu);
        tw_ilac_kul_tal = (TextView)findViewById(R.id.textView_icerik_ilac_kullanimi);

        try {
            tw_ilac_adi.setText(ilac_adi);
            tw_ilac_turu.setText(ilac_turu);
            tw_ilac_kul_tal.setText(ilac_kul_tal);
            youTubeView = (YouTubePlayerView) findViewById(R.id.youtube_view);
            youTubeView.initialize(YOUTUBE_API_KEY, ilactanit.this);    //API Key'i kullanarak görüntüleyiciyi başlat
        }
        catch (Exception ex){
            Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    @Override               //Başlatma başarılı olursa şu linkteki videoyu yükle
    public void onInitializationSuccess(YouTubePlayer.Provider provider, YouTubePlayer youTubePlayer, boolean status) {
        try {
            if (!status) {
                youTubePlayer.cueVideo(ilac_url);
            }
        }
        catch (Exception ex){
            Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
        }

    }

    @Override    //Başlatma başarısız olursa şunları yap.
    public void onInitializationFailure(YouTubePlayer.Provider provider, YouTubeInitializationResult errorReason) {
        try {
            if (errorReason.isUserRecoverableError()) {  // Kullanıcı tarafından kurtarılabilir bir hata olursa kullanıcının hatadan kurtulmasını sağlayacak bir diyalog görüntülenir.
                errorReason.getErrorDialog(this, RECOVERY_REQUEST).show();
            } else {
                String error = String.format(getString(R.string.player_error), errorReason.toString());
                Toast.makeText(this, error, Toast.LENGTH_LONG).show();              // // Kullanıcı tarafından kurtarılamayan bir hata olursa R.string.player_error metnini ve hata kodunu görüntüle.
            }
        }
        catch (Exception ex){
            Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
        }
    }

    @Override
    protected void onActivityResult(int requestCode, int resultCode, Intent data) { // Kullanıcı tarafından kurtarılabilir bir hatadan dönüşünde hatanın giderilip giderilmediğini öğrenmek için tekrar başlatıyoruz.
        try {
            if (requestCode == RECOVERY_REQUEST) {
                youTubeView.initialize(YOUTUBE_API_KEY, this);
            }
        }
        catch (Exception ex){
            Toast.makeText(this, ex.toString(), Toast.LENGTH_SHORT).show();
        }
    }
}
