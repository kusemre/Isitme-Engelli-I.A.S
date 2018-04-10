package com.example.emku.ilacanlatimsistemiadmin;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapPrimitive;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

public class ServiceManager {
    private static final String NAME_SPACE = "http://192.168.1.8/";
    private static final String SERVICE_URL = "http://192.168.1.8/ilacService.asmx";
    private static final String KULLANILACAK_METOD_ILAC_TURU_GETIR = "ilac_turu_getir";
    private static final String KULLANILACAK_METOD_ILAC_KAYDET = "ilac_kaydet";
    private static final String KULLANILACAK_METOD_ILAC_GETIR = "ilac_getir";
    private static final String KULLANILACAK_METOD_ILAC_SIL = "ilac_sil";

    private static final String SOAP_DOGRULA_ACTION_ILAC_GETIR = NAME_SPACE + KULLANILACAK_METOD_ILAC_GETIR;
    private static final String SOAP_DOGRULA_ACTION_ILAC_TURU_GETIR = NAME_SPACE + KULLANILACAK_METOD_ILAC_TURU_GETIR;
    private static final String SOAP_DOGRULA_ACTION_ILAC_KAYDET = NAME_SPACE + KULLANILACAK_METOD_ILAC_KAYDET;
    private static final String SOAP_DOGRULA_ACTION_ILAC_SIL = NAME_SPACE + KULLANILACAK_METOD_ILAC_SIL;

    SoapObject soapObject;
    SoapSerializationEnvelope soapSerializationEnvelope;
    HttpTransportSE httpTransportSE;

    public String[] ilac_turu_getir() {

        soapObject = new SoapObject(NAME_SPACE,KULLANILACAK_METOD_ILAC_TURU_GETIR);
        soapSerializationEnvelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        soapSerializationEnvelope.dotNet = true;
        soapSerializationEnvelope.encodingStyle = SoapEnvelope.ENC;
        soapSerializationEnvelope.setAddAdornments( false);
        soapSerializationEnvelope.implicitTypes = false ;
        soapSerializationEnvelope.setOutputSoapObject(soapObject);

        httpTransportSE = new HttpTransportSE(SERVICE_URL);
        httpTransportSE.debug = true;
        try {
            httpTransportSE.call(SOAP_DOGRULA_ACTION_ILAC_TURU_GETIR, soapSerializationEnvelope);
            SoapObject response =(SoapObject) soapSerializationEnvelope.bodyIn;
            SoapObject response1 = (SoapObject) response.getProperty(0);
            String gelen = response1.toString().substring(8,response1.toString().length()-1);
            String[] veriler = gelen.split(";");
            String[] esittir_ayristir = new String[veriler.length];
            for(int i=0 ; i<esittir_ayristir.length-1;i++)
            {
                String[] parcalanan = veriler[i].split("=");
                esittir_ayristir[i] = parcalanan[1].toString();
            }
            String[] gidecek_veri = new String[esittir_ayristir.length-1];

            for (int i = 0; i<gidecek_veri.length;i++)
            {
                gidecek_veri[i] = esittir_ayristir[i];
            }
            return gidecek_veri;
        } catch (Exception ex) {
            ex.printStackTrace();
            String[] error = {"Veri Bulunamadı..."};
            return error;
        }
    }
    public String ilac_kaydet(String ilac_adi,int ilac_tur_indis,String ilac_kul_tal,String qr_kod,String ilac_url) {

        soapObject = new SoapObject(NAME_SPACE,KULLANILACAK_METOD_ILAC_KAYDET);
        soapObject.addProperty("ilac_adi",ilac_adi);
        soapObject.addProperty("ilac_tur_indis",ilac_tur_indis);
        soapObject.addProperty("ilac_kul_tal",ilac_kul_tal);
        soapObject.addProperty("qr_kod",qr_kod);
        soapObject.addProperty("ilac_url",ilac_url);

        soapSerializationEnvelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        soapSerializationEnvelope.dotNet = true;
        soapSerializationEnvelope.encodingStyle = SoapEnvelope.ENC;
        soapSerializationEnvelope.setAddAdornments( false);
        soapSerializationEnvelope.implicitTypes = false ;
        soapSerializationEnvelope.setOutputSoapObject(soapObject);

        httpTransportSE = new HttpTransportSE(SERVICE_URL);
        httpTransportSE.debug = true;
        try {
            httpTransportSE.call(SOAP_DOGRULA_ACTION_ILAC_KAYDET, soapSerializationEnvelope);
            SoapPrimitive primitive = (SoapPrimitive) soapSerializationEnvelope.getResponse();
            return primitive.toString();
        } catch (Exception ex) {
            ex.printStackTrace();
            return "Sunucu aktif değil. Hata kodu ->" + ex.toString();
        }
    }
    public String[] ilac_getir(String qr_kod) {

        soapObject = new SoapObject(NAME_SPACE,KULLANILACAK_METOD_ILAC_GETIR);
        soapObject.addProperty("qr_kod_no",qr_kod);
        soapSerializationEnvelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        soapSerializationEnvelope.dotNet = true;
        soapSerializationEnvelope.encodingStyle = SoapEnvelope.ENC;
        soapSerializationEnvelope.setAddAdornments( false);
        soapSerializationEnvelope.implicitTypes = false ;
        soapSerializationEnvelope.setOutputSoapObject(soapObject);

        httpTransportSE = new HttpTransportSE(SERVICE_URL);
        httpTransportSE.debug = true;
        try {
            httpTransportSE.call(SOAP_DOGRULA_ACTION_ILAC_GETIR, soapSerializationEnvelope);
            SoapObject response =(SoapObject) soapSerializationEnvelope.bodyIn;
            SoapObject response1 = (SoapObject) response.getProperty(0);
            String gelen = response1.toString().substring(8,response1.toString().length()-1);
            String[] veriler = gelen.split(";");
            String[] gidecek_veri = new String[veriler.length];
            for(int i=0 ; i<gidecek_veri.length-1;i++)
            {
                String[] parcalanan = veriler[i].split("=");
                gidecek_veri[i] = parcalanan[1];
            }
            return gidecek_veri;
        } catch (Exception ex) {
            ex.printStackTrace();
            return new String[]{"Veri Bulunamadı..."};
        }
    }
    public String ilac_sil(int id) {

        soapObject = new SoapObject(NAME_SPACE,KULLANILACAK_METOD_ILAC_SIL);
        soapObject.addProperty("id",id);
        soapSerializationEnvelope = new SoapSerializationEnvelope(SoapEnvelope.VER11);
        soapSerializationEnvelope.dotNet = true;
        soapSerializationEnvelope.encodingStyle = SoapEnvelope.ENC;
        soapSerializationEnvelope.setAddAdornments( false);
        soapSerializationEnvelope.implicitTypes = false ;
        soapSerializationEnvelope.setOutputSoapObject(soapObject);

        httpTransportSE = new HttpTransportSE(SERVICE_URL);
        httpTransportSE.debug = true;
        try {
            httpTransportSE.call(SOAP_DOGRULA_ACTION_ILAC_SIL, soapSerializationEnvelope);
            SoapPrimitive primitive = (SoapPrimitive) soapSerializationEnvelope.getResponse();
            return primitive.toString();
        } catch (Exception ex) {
            ex.printStackTrace();
            return "Sunucu aktif değil. Hata kodu ->" + ex.toString();
        }
    }
}