/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package proyecto1;

import javax.swing.JLabel;
import javax.swing.JTextField;

/**
 *
 * @author Leo
 */
public class Camara_Compensacion {
    public float suma;
    public int verificacion1=0,verificacion2=0,m,n; 
    public static int micro;
    public static int l,index;
    public int p,k,o;
    Microfilm mic = new Microfilm();
    Proyecto1 pr = new Proyecto1();
    Almacen a = new Almacen();
    String[]cuentasMicroDeb,chequesMicroDeb,cuentasMicroAb,chequesMicroAb;
    //---------------------------------------------------------------------------------------------
    //---------------------------------------------------------------------------------------------
    public void Ingresar_Cheque(long cuentadeb, int pin, long cuentabon, String banco, long cheque, double cantidad){
      if("IPC1".equals(banco)||"ipc1".equals(banco)){
        for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuentadeb){
                 if(a.pines[i]==pin){
                    if(a.fondos[i]>=cantidad){
                                a.chequesCobrar[i][p]=cheque;
                                p++;
                                verificacion1++;
                                break;
                                           }
                    else{ Proyecto1.receptorResultado= new JLabel("Los fondos no son suficientes");
                          Proyecto1.receptorResultado.setBounds(0,200,150,25);
                          Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                    break;}
                                       }
                else{Proyecto1.receptorResultado= new JLabel("El Pin no coincide");
                     Proyecto1.receptorResultado.setBounds(0,200,150,25);
                     Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                     break;}
                                      }
                                            }
                                              }
       if("IPC1".equals(banco)||"ipc1".equals(banco)){
        for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuentabon && verificacion1!=0){
                                a.chequesAbonar[i][k]=cheque;
                                k++;
                                verificacion2++;
                                break;                            
                                      }                 
                                            }}
       else{
           for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuentabon && verificacion1!=0){
                                a.chequesAjenos[i][o]=cheque;    
                                o++;
                                verificacion2++;
                                break;                            
                                      }}                
       }
        if(verificacion1==0){
            Proyecto1.receptorResultado= new JLabel("Numero de cuenta principal no encontrado");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                            }                              
        if(verificacion2==0){
            Proyecto1.receptorResultado= new JLabel("Numero de cuenta secundaria no encontrado");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                            }                   
        p=0;k=0;o=0;
       
    }

    public void Cobrar_Cheques(){
        for(int i=0; i<a.cuentas.length; i++){
            for(int j=0; j<10;j++){
                if(a.chequesAbonar[i][j]!=0){
                suma+=a.chequesAbonar[i][j];
                cuentasMicroAb[m]=String.valueOf(a.cuentas[i]);
                chequesMicroAb[m]=String.valueOf(a.chequesAbonar[i][j]);
                m++;
                a.chequesAbonar[i][j]=0;
                                  
            }}
            if(a.cuentas[i]!=0){
               a.cuentas[i]+=suma;
               suma=0;
                                }
                                                 }
        
        for(int i=0; i<a.cuentas.length; i++){  
            for(int j=0; j<10;j++){
                if(a.chequesCobrar[i][j]!=0){
                suma+=a.chequesCobrar[i][j];
                cuentasMicroDeb[n]=String.valueOf(a.cuentas[i]);
                chequesMicroDeb[n]=String.valueOf(a.chequesCobrar[i][j]);
                n++;
                a.chequesCobrar[i][j]=0;
                                  
       
                                   }}
            if(a.cuentas[i]!=0){
               a.cuentas[i]-=suma;
               suma=0;
                                }   
        }
        m=0;n=0;micro++;
        mic.llenar(cuentasMicroAb, chequesMicroAb, cuentasMicroDeb, chequesMicroDeb);
      Proyecto1.receptorResultado= new JLabel("Listo");   
      Proyecto1.receptorResultado.setBounds(0,200,150,25);
      Proyecto1.f1_3.add(Proyecto1.receptorResultado);
    
    }

        public void menu(int entrada){
            switch(entrada){
                case 0:
                    Proyecto1.receptor1 = new JLabel("Ingrese cuenta a debitar");
                    Proyecto1.receptor1.setBounds(0,0,200,25);
                    Proyecto1.receptor1.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor1);
                    Proyecto1.t1= new JTextField("solo numeros");
                    Proyecto1.t1.setBounds(0,25,200,25);
                    Proyecto1.t1.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t1);//
                    Proyecto1.receptor2 = new JLabel("Ingrese numero de pin");
                    Proyecto1.receptor2.setBounds(0,50,200,25);
                    Proyecto1.receptor2.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor2);
                    Proyecto1.t2= new JTextField("solo numeros..");
                    Proyecto1.t2.setBounds(0,75,200,25);
                    Proyecto1.t2.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t2);//
                    Proyecto1.receptor3 = new JLabel("Ingrese cuenta a abonar");
                    Proyecto1.receptor3.setBounds(0,100,200,25);
                    Proyecto1.receptor3.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor3);
                    Proyecto1.t3= new JTextField("solo numeros");
                    Proyecto1.t3.setBounds(0,125,200,25);
                    Proyecto1.t3.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t3);//
                    Proyecto1.receptor4 = new JLabel("Ingrese banco");
                    Proyecto1.receptor4.setBounds(250,0,200,25);
                    Proyecto1.receptor4.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor4);
                    Proyecto1.t4= new JTextField("banco aca..");
                    Proyecto1.t4.setBounds(250,25,200,25);
                    Proyecto1.t4.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t4);//
                    Proyecto1.receptor5 = new JLabel("Ingrese No.cheque");
                    Proyecto1.receptor5.setBounds(250,50,200,25);
                    Proyecto1.receptor5.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor5);
                    Proyecto1.t5= new JTextField("solo numeros..");
                    Proyecto1.t5.setBounds(250,75,200,25);
                    Proyecto1.t5.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t5);//
                    Proyecto1.receptor6 = new JLabel("Ingrese cantidad");
                    Proyecto1.receptor6.setBounds(250,100,200,25);
                    Proyecto1.receptor6.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.receptor6);
                    Proyecto1.t6= new JTextField("solo numeros..");
                    Proyecto1.t6.setBounds(250,125,200,25);
                    Proyecto1.t6.setVisible(true);
                    Proyecto1.f2_1.add(Proyecto1.t6);// 
                    break;
                case 1:
                    Proyecto1.receptor1 = new JLabel("Procesando...");
                    Proyecto1.receptor1.setBounds(0,0,200,25);
                    Proyecto1.receptor1.setVisible(true);
                    Proyecto1.f2_2.add(Proyecto1.receptor1);
                    break;
                default:
            }
        }
}
