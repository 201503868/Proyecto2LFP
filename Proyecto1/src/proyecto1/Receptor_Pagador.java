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
public class Receptor_Pagador {
   private int verificacion1=0,verificacion2=0;
   private static int j;
   String resultado;
   Almacen a = new Almacen();
   Proyecto1 p = new Proyecto1();
    //------------------------------------------------------------------------------------
    public void Retirar_Efectivo(long cuenta, int pin, double cantidad){
        for(int i=0; i<a.cuentas.length; i++){
            if(a.cuentas[i]==cuenta){
                if(a.pines[i]==pin){
                    if(a.fondos[i]>=cantidad){
                                a.fondos[i]-=cantidad;
                                verificacion1++;
                                Proyecto1.receptorResultado= new JLabel("EXITO!! La cuenta: "+a.cuentas[i]+" tiene ahora Q"+a.fondos[i]);
                                Proyecto1.receptorResultado.setBounds(0,200,150,25);
                                Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                                break;
                                                  }
                    else{ Proyecto1.receptorResultado= new JLabel("Los fondos no son suficientes");
                          Proyecto1.receptorResultado.setBounds(0,200,150,25);
                          Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                          break;}
                                       }
                else{ Proyecto1.receptorResultado= new JLabel("El Pin no coincide");
                      Proyecto1.receptorResultado.setBounds(0,200,150,25);
                      Proyecto1.f1_3.add(Proyecto1.receptorResultado); 
                      break;}
                                            }
                                           }
        if(verificacion1==0){
            Proyecto1.receptorResultado= new JLabel("Numero de cuenta no encontrado");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                           }
        verificacion1=0;
                                                                       }
    //-----------------------------------------------------------------------------------------
    public void Depositar(long cuenta, double cantidad){
        for(int i=0; i<a.cuentas.length; i++){
            if(a.cuentas[i]==cuenta){
                a.fondos[i]+=cantidad;
                verificacion1++;
                Proyecto1.receptorResultado= new JLabel("La cuenta: "+a.cuentas[i]+" tiene ahora Q"+a.fondos[i]);
                Proyecto1.receptorResultado.setBounds(0,200,150,25);
                Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                break;
                                            }
                                           }
        if(verificacion1==0){
            Proyecto1.receptorResultado= new JLabel("Numero de cuenta no encontrado");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
        }
    verificacion1=0;       
                                                       }
    //--------------------------------------------------------------------------------------------------
    public void Pago(String tipo,int pin,String fecha, String recibo, long cuenta, double cantidad){
        if("agua".equals(tipo)||"telefono".equals(tipo)||"electricidad".equals(tipo)){     
             for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuenta){
                 if(a.pines[i]==pin){
                    if(a.fondos[i]>=cantidad){
                                a.fondos[i]-=cantidad;
                                a.recibos[j]="_"+recibo+"-"+fecha+"-"+a.cuentas[i]+"_";
                                j++;
                                verificacion1++;
                               Proyecto1.receptorResultado= new JLabel("La cuenta: "+a.cuentas[i]+" tiene ahora Q"+a.fondos[i]+" debido al pago de "+tipo);
                               Proyecto1.receptorResultado.setBounds(0,200,150,25);
                               Proyecto1.f1_3.add(Proyecto1.receptorResultado); 
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
             if(verificacion1==0){
            Proyecto1.receptorResultado= new JLabel("Numero de cuenta no encontrado");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                           }
                                                                                     }
        else{
            Proyecto1.receptorResultado= new JLabel("tipo de servicio ingresado incorrecto");
            Proyecto1.receptorResultado.setBounds(0,200,150,25);
            Proyecto1.f1_3.add(Proyecto1.receptorResultado);
        }
    }
    //-------------------------------------------------------------------------------
    public void Cobros_CAjena(long cuenta1, int pin, long cuenta2, double cantidad){
        for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuenta1){
                 if(a.pines[i]==pin){
                    if(a.fondos[i]>=cantidad){
                                a.fondos[i]-=cantidad;
                                verificacion1++;
                                Proyecto1.receptorResultado= new JLabel("La cuenta: "+a.cuentas[i]+" tiene ahora Q"+a.fondos[i]);
                                Proyecto1.receptorResultado.setBounds(0,200,150,25);
                                Proyecto1.f1_3.add(Proyecto1.receptorResultado);
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
       
        for(int i=0; i<a.cuentas.length; i++){
               if(a.cuentas[i]==cuenta2 && verificacion1!=0){
                                a.fondos[i]+=cantidad;
                                verificacion2++;
                                Proyecto1.receptorResultado= new JLabel("La cuenta: "+a.cuentas[i]+" tiene ahora Q"+a.fondos[i]);
                                Proyecto1.receptorResultado.setBounds(0,200,150,25);
                                Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                                break;                            
                                      }                 
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
                                                                            }  
    //---------------------------------------------------------------------------------------
    public void menu(int ingreso){
         switch(ingreso){
            case 0: 
                Proyecto1.receptor1 = new JLabel("Ingrese cuenta");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("solo numeros..");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.t2);//
                Proyecto1.receptor3 = new JLabel("Ingrese cantidad");
                Proyecto1.receptor3.setBounds(0,100,200,25);
                Proyecto1.receptor3.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.receptor3);
                Proyecto1.t3= new JTextField("solo numeros..");
                Proyecto1.t3.setBounds(0,125,200,25);
                Proyecto1.t3.setVisible(true);
                Proyecto1.f1_1.add(Proyecto1.t3);//
                break;
            case 1: 
                Proyecto1.receptor1 = new JLabel("Ingrese cuenta");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f1_2.add(Proyecto1.receptor1);                
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f1_2.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese cantidad");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f1_2.add(Proyecto1.receptor2);                
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f1_2.add(Proyecto1.t2);//
                break;
            case 2: 
                Proyecto1.receptor1 = new JLabel("Ingrese servicio");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("agua,telefono,electricidad");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese numero de pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t2);//
                Proyecto1.receptor3 = new JLabel("Ingrese fecha");
                Proyecto1.receptor3.setBounds(0,100,200,25);
                Proyecto1.receptor3.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor3);
                Proyecto1.t3= new JTextField("fecha aca..");
                Proyecto1.t3.setBounds(0,125,200,25);
                Proyecto1.t3.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t3);//
                Proyecto1.receptor4 = new JLabel("Ingrese recibo");
                Proyecto1.receptor4.setBounds(250,0,200,25);
                Proyecto1.receptor4.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor4);
                Proyecto1.t4= new JTextField("recibo aca..");
                Proyecto1.t4.setBounds(250,25,200,25);
                Proyecto1.t4.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t4);//
                Proyecto1.receptor5 = new JLabel("Ingrese cuenta");
                Proyecto1.receptor5.setBounds(250,50,200,25);
                Proyecto1.receptor5.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor5);
                Proyecto1.t5= new JTextField("solo numeros..");
                Proyecto1.t5.setBounds(250,75,200,25);
                Proyecto1.t5.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t5);//
                Proyecto1.receptor6 = new JLabel("Ingrese cantidad");
                Proyecto1.receptor6.setBounds(250,100,200,25);
                Proyecto1.receptor6.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.receptor6);
                Proyecto1.t6= new JTextField("solo numeros..");
                Proyecto1.t6.setBounds(250,125,200,25);
                Proyecto1.t6.setVisible(true);
                Proyecto1.f1_3.add(Proyecto1.t6);// 
                break;
            case 3:
                Proyecto1.receptor1 = new JLabel("Ingrese cuenta a debitar");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("solo numeros..");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese numero de pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.t2);//
                Proyecto1.receptor3 = new JLabel("Ingrese cuenta a abonar");
                Proyecto1.receptor3.setBounds(0,100,200,25);
                Proyecto1.receptor3.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.receptor3);
                Proyecto1.t3= new JTextField("solo numeros..");
                Proyecto1.t3.setBounds(0,125,200,25);
                Proyecto1.t3.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.t3);//
                Proyecto1.receptor4 = new JLabel("Ingrese cantidad a retirar");
                Proyecto1.receptor4.setBounds(250,0,200,25);
                Proyecto1.receptor4.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.receptor4);
                Proyecto1.t4= new JTextField("solo numeros..");
                Proyecto1.t4.setBounds(250,25,200,25);
                Proyecto1.t4.setVisible(true);
                Proyecto1.f1_4.add(Proyecto1.t4);//
                break;
            default:
                        }
                        }
    //-----------------------------------------------------------------------------------------
   
}
    

