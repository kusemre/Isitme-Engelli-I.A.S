package com.example.emku.ilacanlatimsistemi;

import org.ksoap2.SoapEnvelope;
import org.ksoap2.serialization.SoapObject;
import org.ksoap2.serialization.SoapSerializationEnvelope;
import org.ksoap2.transport.HttpTransportSE;

public class ServiceManager {
    private static final String NAME_SPACE = "http://192.168.1.8/";
    private static final String SERVICE_URL = "http://192.168.1.8/ilacService.asmx";
    private static final String KULLANILACAK_METOD = "ilac_getir";
    private static final String SOAP_DOGRULA_ACTION = NAME_SPACE + KULLANILACAK_METOD;

    SoapObject soapObject;
    SoapSerializationEnvelope soapSerializationEnvelope;
    HttpTransportSE httpTransportSE;

    public String[] ilac_getir(String qr_kod) {

        soapObject = new SoapObject(NAME_SPACE,KULLANILACAK_METOD);
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
            httpTransportSE.call(SOAP_DOGRULA_ACTION, soapSerializationEnvelope);
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
}