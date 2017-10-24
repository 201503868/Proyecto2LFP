/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package proyecto1;

/**
 *
 * @author Leo
 */
public class Microfilm {
    static String[]cuentasMicroAb1,chequesMicroAb1,cuentasMicroAb2,chequesMicroAb2,cuentasMicroAb3,chequesMicroAb3;
    
    
   static String[]cuentasMicroDeb1, chequesMicroDeb1,cuentasMicroDeb2, chequesMicroDeb2,cuentasMicroDeb3,chequesMicroDeb3;
            
      public void consultar(){
        Camara_Compensacion c = new Camara_Compensacion();
        String[] Microfilms = new String[Camara_Compensacion.micro];
        for(int i=1;i<Camara_Compensacion.micro+1;i++){
            Microfilms[i-1]="Microfilm"+i;
                                    }
        
      
      }
      
      public void llenar(String[]cuentasAb, String[]chequesAb, String[]cuentasDeb,String[]chequesDeb){
          switch(Camara_Compensacion.micro){
              case 1:
                  cuentasMicroAb1=cuentasAb;
                  chequesMicroAb1=chequesAb;
                  cuentasMicroDeb1=cuentasDeb;
                  chequesMicroDeb1=chequesDeb;
                  break;
              case 2:
                  cuentasMicroAb2=cuentasAb;
                  chequesMicroAb2=chequesAb;
                  cuentasMicroDeb2=cuentasDeb;
                  chequesMicroDeb2=chequesDeb;
                  break;    
              case 3:
                  cuentasMicroAb3=cuentasAb;
                  chequesMicroAb3=chequesAb;
                  cuentasMicroDeb3=cuentasDeb;
                  chequesMicroDeb3=chequesDeb;
                  break;
              default:
          }
      }
      
}
