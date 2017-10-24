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
public class Servicio_cliente {
  int a;
  String cambio;
  Almacen al = new Almacen();
  Proyecto1 p = new Proyecto1();
  
   public void Nueva_Cuenta(String tipo, int pin,String nombre,String nacimiento){
       for(int i=0;i<al.cuentas.length;i++){
           if(al.cuentas[i]!=0){
               al.tipo_cuenta[i]=tipo;
               al.pines[i]=pin;
               al.cuentas[i]=201500000+i;
               al.nombres[i]=nombre;
               al.nacimientos[i]=nacimiento;
               a=i;
               break;
                            }
                                         }
       Proyecto1.receptorResultado= new JLabel("cuenta creada, su numero de cuenta es ahora: "+al.cuentas[a]);
       Proyecto1.receptorResultado.setBounds(0,200,150,25);
       Proyecto1.f1_3.add(Proyecto1.receptorResultado);                                                                         
   }
   
   public void modificar(long cuenta, int pin,String dato, String cambio){
       System.out.println("ingrese el datos a modificar el cual puede ser: ");
       System.out.println("''tipo'' para tipo de cuenta, ''pin'' para pin de la cuenta, ");
       System.out.println("''nacimiento'' para fecha de nacimiento y ");
       System.out.println("''nombre'' para el nombre del dueño de la cuenta");
       for(int i=0; i<al.cuentas.length; i++){
               if(al.cuentas[i]==cuenta){
                 if(al.pines[i]==pin){
                       switch(dato){           
                          case "tipo":
                                if("premium".equals(cambio)||"oro".equals(cambio)||"ordinaria".equals(cambio)){
                                        al.tipo_cuenta[i]=cambio;
                                                }
                                break;
                          case "pin":
                                        al.pines[i]=Integer.parseInt(cambio);
                                break;
                          case "nacimiento":
                                        al.nacimientos[i]=cambio;
                                break;
                          case "nombre":
                                        al.nombres[i]=cambio;
                                break;
                          default:
                              Proyecto1.receptorResultado= new JLabel("Entrada incorrecta");
                              Proyecto1.receptorResultado.setBounds(0,200,150,25);
                              Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                       }         
                                break;
                                           
                                   }
                else{Proyecto1.receptorResultado= new JLabel("El Pin no coincide");
                     Proyecto1.receptorResultado.setBounds(0,200,150,25);
                     Proyecto1.f1_3.add(Proyecto1.receptorResultado);
                break;}
                                      }
                                            }
   } 
   
   public void eliminar(long cuenta, int pin){
       for(int i=0; i<al.cuentas.length; i++){
               if(al.cuentas[i]==cuenta){
                 if(al.pines[i]==pin){
                       al.tipo_cuenta[i]="vacio";
                       al.pines[i]=0;
                       al.cuentas[i]=0;
                       al.nombres[i]="vacio";
                       al.nacimientos[i]="vacio";
                                      }
                                            }
                                              }
       Proyecto1.receptorResultado= new JLabel("cuenta eliminada");
       Proyecto1.receptorResultado.setBounds(0,200,150,25);
       Proyecto1.f1_3.add(Proyecto1.receptorResultado);
   }
   
   public void menu(int entrada){
       switch(entrada){
            case 0:
                Proyecto1.receptor1 = new JLabel("Ingrese tipo de cuenta");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("(premium,oro,ordinaria)..");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese numero de pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.t2);//
                Proyecto1.receptor3 = new JLabel("Ingrese nombre completo");
                Proyecto1.receptor3.setBounds(0,100,200,25);
                Proyecto1.receptor3.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.receptor3);
                Proyecto1.t3= new JTextField("nombre aca..");
                Proyecto1.t3.setBounds(0,125,200,25);
                Proyecto1.t3.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.t3);//
                Proyecto1.receptor4 = new JLabel("Ingrese fecha de nacimiento");
                Proyecto1.receptor4.setBounds(250,0,200,25);
                Proyecto1.receptor4.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.receptor4);
                Proyecto1.t4= new JTextField("D/MM/YYYY");
                Proyecto1.t4.setBounds(250,25,200,25);
                Proyecto1.t4.setVisible(true);
                Proyecto1.f3_1.add(Proyecto1.t4);//
                break;
            case 1:
                Proyecto1.receptor1 = new JLabel("Ingrese cuenta");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("solo numeros..");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.t2);//
                Proyecto1.receptor3 = new JLabel("Ingrese dato a modificar");
                Proyecto1.receptor3.setBounds(0,100,200,25);
                Proyecto1.receptor3.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.receptor3);
                Proyecto1.t3= new JTextField("(tipo,pin,nacimiento o nombre)");
                Proyecto1.t3.setBounds(0,125,200,25);
                Proyecto1.t3.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.t3);//
                Proyecto1.receptor4 = new JLabel("Ingrese el nuevo valor");
                Proyecto1.receptor4.setBounds(250,0,200,25);
                Proyecto1.receptor4.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.receptor4);
                Proyecto1.t4= new JTextField("nuevo valor..");
                Proyecto1.t4.setBounds(250,25,200,25);
                Proyecto1.t4.setVisible(true);
                Proyecto1.f3_2.add(Proyecto1.t4);//
                break;
            case 2:
                Proyecto1.receptor1 = new JLabel("Ingrese cuenta");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f3_3.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("solo numeros..");
                Proyecto1.t1.setBounds(0,25,200,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f3_3.add(Proyecto1.t1);//
                Proyecto1.receptor2 = new JLabel("Ingrese pin");
                Proyecto1.receptor2.setBounds(0,50,200,25);
                Proyecto1.receptor2.setVisible(true);
                Proyecto1.f3_3.add(Proyecto1.receptor2);
                Proyecto1.t2= new JTextField("solo numeros..");
                Proyecto1.t2.setBounds(0,75,200,25);
                Proyecto1.t2.setVisible(true);
                Proyecto1.f3_3.add(Proyecto1.t2);//
                break;
            default:    
       }
   }




   
}
