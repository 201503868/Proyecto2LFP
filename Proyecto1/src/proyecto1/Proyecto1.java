/*
 * To change this license header, choose License Headers in Project Properties.
 * To change this template file, choose Tools | Templates
 * and open the template in the editor.
 */
package proyecto1;
import javax.swing.*;
import javax.swing.JPanel;
import javax.swing.JTabbedPane;
import java.awt.*;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.awt.event.ItemEvent;
import java.awt.event.ItemListener;
/**
 *
 * @author Leo
 */
public class Proyecto1 extends JFrame{

 static JLabel receptor1,receptor2,receptor3,receptor4,receptor5,receptor6,receptorResultado;
 static JTextField t1= new JTextField(),t2= new JTextField(),t3= new JTextField(),t4= new JTextField(),
         t5= new JTextField(),t6= new JTextField();
 static JButton bRetirar1,bRetirar2,bRetirar3,bRetirar4,bCC,bSC1,bSC2,bSC3,bJ;
 static JComboBox combo1,combo2,combo3,combo4,combo5;
 static JInternalFrame f1_1,f1_2,f1_3,f1_4,f2_1,f2_2,f3_1,f3_2,f3_3,f4,f5_1,f5_2; 
 static JList list1;
 String[] receptor={"retirar","depositar","pago","cuenta ajena"};
 String[] camara={"Ingresar cheque","cobrar","elegir"};
 String[] servicio={"crear","modificar","eliminar"};
 String[] juridico={"ingresar ley","ver leyes","elegir"};
 static int val;
 
    public void Proyecto(){
        this.setTitle("Sistema Bancario ''IPC1''");
        this.setSize(750, 550);
        this.setLayout(new BorderLayout());
        this.setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
        this.setPreferredSize(new Dimension(500,500));
        this.setVisible(true);
        
        JTabbedPane TabbedPane = new JTabbedPane();
        JPanel panel1 = new JPanel();
        panel1.setLayout(null);
        JPanel panel2 = new JPanel();
        panel2.setLayout(null);
        JPanel panel3 = new JPanel();
        panel3.setLayout(null);
        JPanel panel4 = new JPanel();
        panel4.setLayout(null);
        JPanel panel5 = new JPanel();
        panel5.setLayout(null);
        
        f1_1 = new JInternalFrame();
        f1_1.setTitle("Procesos aqui");
        f1_1.setLayout(null);
        f1_1.setBounds(200,0,950,750);
        f1_1.setVisible(false);
        panel1.add(f1_1);
        
        f1_2 = new JInternalFrame();
        f1_2.setTitle("Procesos aqui");
        f1_2.setLayout(null);
        f1_2.setBounds(200,0,950,750);
        f1_2.setVisible(false);
        panel1.add(f1_2);
        
        f1_3 = new JInternalFrame();
        f1_3.setTitle("Procesos aqui");
        f1_3.setLayout(null);
        f1_3.setBounds(200,0,950,750);
        f1_3.setVisible(false);
        panel1.add(f1_3);
        
        f1_4 = new JInternalFrame();
        f1_4.setTitle("Procesos aqui");
        f1_4.setLayout(null);
        f1_4.setBounds(200,0,950,750);
        f1_4.setVisible(false);
        panel1.add(f1_4);
        
        f2_1 = new JInternalFrame();
        f2_1.setTitle("Procesos aqui");
        f2_1.setLayout(null);
        f2_1.setBounds(200,0,950,750);
        f2_1.setVisible(false);
        panel2.add(f2_1);
        
        f2_2 = new JInternalFrame();
        f2_2.setTitle("Procesos aqui");
        f2_2.setLayout(null);
        f2_2.setBounds(200,0,950,750);
        f2_2.setVisible(false);
        panel2.add(f2_2);
        
        f3_1 = new JInternalFrame();
        f3_1.setTitle("Procesos aqui");
        f3_1.setLayout(null);
        f3_1.setBounds(200,0,950,750);
        f3_1.setVisible(false);
        panel3.add(f3_1);
        
        f3_2 = new JInternalFrame();
        f3_2.setTitle("Procesos aqui");
        f3_2.setLayout(null);
        f3_2.setBounds(200,0,950,750);
        f3_2.setVisible(false);
        panel3.add(f3_2);
        
        f3_3 = new JInternalFrame();
        f3_3.setTitle("Procesos aqui");
        f3_3.setLayout(null);
        f3_3.setBounds(200,0,950,750);
        f3_3.setVisible(false);
        panel3.add(f3_3);
        
        f4 = new JInternalFrame();
        f4.setTitle("Procesos aqui");
        f4.setLayout(null); 
        f4.setBounds(200,0,950,750);
        f4.setVisible(true);
        panel4.add(f4);
        
        f5_1 = new JInternalFrame();
        f5_1.setTitle("Procesos aqui");
        f5_1.setLayout(null);
        f5_1.setBounds(200,0,950,750);
        f5_1.setVisible(false);
        panel5.add(f5_1);
        
        f5_2 = new JInternalFrame();
        f5_2.setTitle("Procesos aqui");
        f5_2.setLayout(null);
        f5_2.setBounds(200,0,950,750);
        f5_2.setVisible(false);
        panel5.add(f5_2);
       
        TabbedPane.addTab("Receptor-Pagador",panel1);
        TabbedPane.addTab("Camara Compensacion",panel2);
        TabbedPane.addTab("Servicio al cliente",panel3);
        TabbedPane.addTab("Microfilm",panel4);
        TabbedPane.addTab("Area juridica",panel5);
        this.getContentPane().add(TabbedPane);
    
        JLabel l1 = new JLabel("BIENVENIDO AL AREA DE RECEPTOR-PAGADOR");
        l1.setBounds(0,0,300,25);
        panel1.add(l1);
        
        JLabel l2 = new JLabel("BIENVENIDO AL AREA DE CAMARA DE COMPENSACION");
        l2.setBounds(0,0,300,25);
        panel2.add(l2);
        
        JLabel l3_1 = new JLabel("BIENVENIDO AL AREA SERVICIO AL CLIENTE");
        l3_1.setBounds(0,0,300,25);
        panel3.add(l3_1);
       
        JLabel l4 = new JLabel("BIENVENIDO AL AREA DE MICROFILM");
        l4.setBounds(0,0,300,25);
        panel4.add(l4);
        
        JLabel l5 = new JLabel("BIENVENIDO AL AREA JURIDICA");
        l5.setBounds(0,0,300,25);
        panel5.add(l5);
        
    //-----------------------------------------------------------------
        Receptor_Pagador rc = new Receptor_Pagador();
        Camara_Compensacion cc = new Camara_Compensacion();
        Servicio_cliente sc = new Servicio_cliente();
        Juridica jur = new Juridica();
    
    
    
        combo1=new JComboBox(receptor);
        combo1.setVisible(true);
        combo1.setBounds(0,50,100,50);
        panel1.add(combo1);
        
        
        
        ItemListener item1 = new ItemListener(){
            @Override
            public void itemStateChanged(ItemEvent ie) {
                val=combo1.getSelectedIndex();
                switch(val){
                    case 0:
                        f1_2.setVisible(false);
                        f1_3.setVisible(false);
                        f1_4.setVisible(false);
                        f1_1.setVisible(true);
                        rc.menu(val);
                        break;
                    case 1:
                        f1_1.setVisible(false);
                        f1_3.setVisible(false);
                        f1_4.setVisible(false);
                        f1_2.setVisible(true);
                        rc.menu(val);
                        break;  
                    case 2:
                        f1_2.setVisible(false);
                        f1_1.setVisible(false);
                        f1_4.setVisible(false);
                        f1_3.setVisible(true);
                        rc.menu(val);
                        break;  
                    case 3:
                        f1_2.setVisible(false);
                        f1_3.setVisible(false);
                        f1_1.setVisible(false);
                        f1_4.setVisible(true);
                        rc.menu(val);
                        break;  
                }}};
        
        combo1.addItemListener(item1);
        
        combo2=new JComboBox(camara);
        combo2.setVisible(true);
        combo2.setBounds(0,50,100,50);
        panel2.add(combo2);
        
        
        ItemListener item2 = new ItemListener(){
            @Override
            public void itemStateChanged(ItemEvent ie) {
                val=combo2.getSelectedIndex();
                switch(val){
                    case 0:
                        f2_2.setVisible(false);
                        f2_1.setVisible(true);
                        cc.menu(val);
                        break;
                    case 1:
                        f2_1.setVisible(false);
                        f2_2.setVisible(true);
                        cc.menu(val);
                        break;  
                }}};
        
        combo2.addItemListener(item2);
        
        combo3=new JComboBox(servicio);
        combo3.setVisible(true);
        combo3.setBounds(0,50,100,50);
        panel3.add(combo3);
        
        
        ItemListener item3 = new ItemListener(){
            @Override
            public void itemStateChanged(ItemEvent ie) {
                val=combo3.getSelectedIndex();
                switch(val){
                    case 0:
                        f3_2.setVisible(false);
                        f3_3.setVisible(false);
                        f3_1.setVisible(true);
                        sc.menu(val);
                        break;
                    case 1:
                        f3_1.setVisible(false);
                        f3_3.setVisible(false);
                        f3_2.setVisible(true);
                        sc.menu(val);
                        break;  
                    case 2:
                        f3_2.setVisible(false);
                        f3_1.setVisible(false);
                        f3_3.setVisible(true);
                        sc.menu(val);
                        break;  
                    }}};
        
        combo3.addItemListener(item3);
        
        combo5=new JComboBox(juridico);
        combo5.setVisible(true);
        combo5.setBounds(0,50,100,50);
        panel5.add(combo5);
        
        ItemListener item5 = new ItemListener(){
            @Override
            public void itemStateChanged(ItemEvent ie) {
                val=combo5.getSelectedIndex();
                switch(val){
                    case 0:
                        f5_2.setVisible(false);
                        f5_1.setVisible(true);
                        jur.menu(val);
                        break;
                    case 1:
                        f5_1.setVisible(false);
                        f5_2.setVisible(true);
                        jur.menu(val);
                        break;  
                }}};
        
        combo5.addItemListener(item5);
        
        
       
    //----------------------Internalframe 1_1 (toma de datos de operacion)------------------------------------------
        
        
        bRetirar1 = new JButton("Ingresar Datos");
        bRetirar1.setVisible(true);
        bRetirar1.setBounds(0,150,100,100);
        
        bRetirar2 = new JButton("Ingresar Datos");
        bRetirar2.setVisible(true);
        bRetirar2.setBounds(0,150,100,100);
        
        bRetirar3 = new JButton("Ingresar Datos");
        bRetirar3.setVisible(true);
        bRetirar3.setBounds(0,150,100,100);
        
        bRetirar4 = new JButton("Ingresar Datos");
        bRetirar4.setVisible(true);
        bRetirar4.setBounds(0,150,100,100);
        
        
        
        ActionListener LRP = new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent ae) {
               switch(val){
                   case 0: 
                         rc.Retirar_Efectivo(Long.parseLong(t1.getText()),Integer.parseInt(t2.getText()),Double.parseDouble(t3.getText()));
                         break;
                   case 1:
                         
                         rc.Depositar(Long.parseLong(Proyecto1.t1.getText()), Double.parseDouble(Proyecto1.t2.getText()));
                         break;
                   case 2:
                         rc.Pago(t1.getText(),Integer.parseInt(t2.getText()),t3.getText(),t4.getText(),Long.parseLong(t5.getText()), Double.parseDouble(t6.getText()));
                         break;
                   case 3:
                         rc.Cobros_CAjena(Long.parseLong(t1.getText()), Integer.parseInt(t2.getText()),Long.parseLong(t3.getText()), Double.parseDouble(t4.getText()));
                         break;
                   default:
               }
               }
            };
        bRetirar1.addActionListener(LRP);
        bRetirar2.addActionListener(LRP);
        bRetirar3.addActionListener(LRP);
        bRetirar4.addActionListener(LRP);
        f1_1.add(bRetirar1);
        f1_2.add(bRetirar2);
        f1_3.add(bRetirar3);
        f1_4.add(bRetirar4);
        
        bCC = new JButton("Ingresar Datos");
        bCC.setVisible(true);
        bCC.setBounds(0,150,100,100);
        ActionListener LCC = new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent ae) {
               switch(val){
                   case 0: 
                         cc.Ingresar_Cheque(Long.parseLong(t1.getText()), Integer.parseInt(t2.getText()),Long.parseLong(t3.getText()), t4.getText(),Long.parseLong(t5.getText()),Double.parseDouble(t6.getText()));
                         break;
                   case 1:
                         cc.Cobrar_Cheques();
                         receptor3 = new JLabel("Se cobro exitosamente");
                         f2_2.add(receptor3);
                         receptor3.setVisible(true);
                         break;
                   default:
               }
               }
            };
        bCC.addActionListener(LCC);
        f2_1.add(bCC);
        
        bSC1 = new JButton("Ingresar Datos");
        bSC1.setVisible(true);
        bSC1.setBounds(0,150,100,100);
        
        bSC2 = new JButton("Ingresar Datos");
        bSC2.setVisible(true);
        bSC2.setBounds(0,150,100,100);
        
        bSC3 = new JButton("Ingresar Datos");
        bSC3.setVisible(true);
        bSC3.setBounds(0,150,100,100);
        
        ActionListener LSC = new ActionListener(){
            @Override
            public void actionPerformed(ActionEvent ae) {
               switch(val){
                   case 0: 
                         sc.Nueva_Cuenta(t1.getText(),Integer.parseInt(t2.getText()),t3.getText(),t4.getText());
                         break;
                   case 1:
                         sc.modificar(Long.parseLong(t1.getText()), Integer.parseInt(t2.getText()),t3.getText(),t4.getText());
                         break;
                   case 2:
                         sc.eliminar(Long.parseLong(t1.getText()),Integer.parseInt(t2.getText()));
                         break;
                   default:
               }
               }
            };
        bSC1.addActionListener(LSC);
        bSC2.addActionListener(LSC);
        bSC2.addActionListener(LSC);
        f3_1.add(bSC1);
        f3_2.add(bSC2);
        f3_3.add(bSC3);
        
        bJ = new JButton("Ingresar Datos");
        bJ.setVisible(false);
        bJ.setBounds(0,150,100,100);
        
        ActionListener LJ;
     LJ = new ActionListener(){
         @Override
         public void actionPerformed(ActionEvent ae) {
             switch(val){
                 case 0:
                     jur.alimentar(t1.getText());
                     break;
                 default:
             }
         }
     };
     bJ.addActionListener(LJ);
     f5_1.add(bJ);
        
    }
    /**
     * @param args the command line arguments
     */
    public static void main(String[] args) {
        Proyecto1 proyecto = new Proyecto1();
        proyecto.Proyecto();
    }
    
}
