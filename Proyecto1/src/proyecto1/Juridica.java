/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package proyecto1;

import javax.swing.JLabel;
import javax.swing.JTextField;
import javax.swing.JList;
/**
 *
 * @author Leo
 */
public class Juridica {
    String[]leyes ={"Artículo 1o.- Las sociedades financieras son instituciones bancarias que actúan\n" +
"como intermediarios financieros especializados en operaciones de banco de\n" +
"inversión, promueven la creación de empresas productivas mediante la\n" +
"captación y canalización de recursos internos y externos de mediano y largo\n" +
"plazos","Artículo 2o.- Las Sociedades Financieras Privadas deberán constituirse en\n" +
"forma de sociedades anónimas y regularán y desenvolverán sus objetivos,\n" +
"funciones y operaciones de conformidad con la presente ley","Artículo 3o.-Para la constitución de las Sociedades\n" +
"Financieras se llenarán los requisitos prescritos en la Ley de Bancos y Grupos\n" +
"Financieros"};
    String[]temporal;
    int l=4;
    
    
    public void alimentar(String ley){
        temporal=leyes;
        l++;
        leyes = new String[l];
        for(int i=0;i<leyes.length;i++){
            if(i<l){
                leyes[i]=temporal[i];
                   }
            else{
                leyes[i]=ley;
                }
        }
    }
    
    public String[] getLey(){
        return leyes;
    }
    
    public void menu(int ingreso){
        switch(ingreso){
            case 0:
                Proyecto1.receptor1 = new JLabel("Ingrese ley");
                Proyecto1.receptor1.setBounds(0,0,200,25);
                Proyecto1.receptor1.setVisible(true);
                Proyecto1.f5_1.add(Proyecto1.receptor1);
                Proyecto1.t1= new JTextField("ley aca...");
                Proyecto1.t1.setBounds(0,25,600,25);
                Proyecto1.t1.setVisible(true);
                Proyecto1.f5_1.add(Proyecto1.t1);//
                break;
            case 1:
                Proyecto1.list1 = new JList(leyes);
                Proyecto1.list1.setBounds(0,0,800,400);
                Proyecto1.list1.setVisible(true);
                Proyecto1.f5_2.add(Proyecto1.list1);
        }
    }


}
