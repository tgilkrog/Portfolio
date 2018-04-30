package GUI;

import java.awt.BorderLayout;
import java.awt.Color;
import java.awt.EventQueue;
import java.awt.FlowLayout;
import java.awt.Font;
import java.awt.event.ActionEvent;
import java.awt.event.ActionListener;
import java.sql.SQLException;
import java.text.ParseException;
import java.util.ArrayList;
import java.util.List;

import javax.swing.DefaultListModel;
import javax.swing.JButton;
import javax.swing.JFrame;
import javax.swing.JLabel;
import javax.swing.JList;
import javax.swing.JOptionPane;
import javax.swing.JPanel;
import javax.swing.JScrollPane;
import javax.swing.border.EmptyBorder;
import javax.swing.border.LineBorder;
import javax.xml.ws.http.HTTPException;

import ModelLayer.Driver;
import ModelLayer.Order;
import GUI.Renderes.OrderListRenderer;
import ControlLayer.OrderController;

public class OrdreUi extends JFrame {

	private JPanel contentPane;
	private JList<Order> lstOrders;
	
	private OrderController oCtr;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					OrdreUi frame = new OrdreUi();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 * @throws SQLException 
	 */
	public OrdreUi() throws SQLException {
		oCtr = new OrderController();
		
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 744, 441);
		contentPane = new JPanel();
		contentPane.setBackground(new Color(227, 225, 224));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JPanel panel = new JPanel();
		panel.setBackground(new Color(204,204,204));
		panel.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel.setBounds(10, 11, 730, 235);
		contentPane.add(panel);
		panel.setLayout(null);
		
		JLabel lblOrdre = new JLabel("Ordre");
		lblOrdre.setFont(new Font("Verdana", Font.BOLD, 15));
		lblOrdre.setBounds(10, 11, 90, 21);
		panel.add(lblOrdre);
		
		DefaultListModel<Order> model = new DefaultListModel<>();
		panel.setLayout(null);
		
		lstOrders = new JList<>(model);
		lstOrders.setBounds(10, 43, 560, 181);
		lstOrders.setBorder(new LineBorder(new Color(0, 0, 0)));
		panel.add(lstOrders);
		
		JButton btnOpretOrdre = new JButton("Opret Ordre");
		btnOpretOrdre.addActionListener((e) -> {
			ViewOrder vo = new ViewOrder();
			vo.setVisible(true);
			vo.buttonView(2);
			});
		
		btnOpretOrdre.setOpaque(true);
		btnOpretOrdre.setForeground(Color.WHITE);
		btnOpretOrdre.setFocusPainted(false);
		btnOpretOrdre.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnOpretOrdre.setBackground(new Color(94, 109, 126));
		btnOpretOrdre.setBounds(600, 41, 120, 45);
		panel.add(btnOpretOrdre);
		
		JButton btnEdit = new JButton("\u00C6ndre Ordre");
		btnEdit.addActionListener((e) -> {
			try {
				showOrder();
			} catch (SQLException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			} catch (ParseException e1) {
				// TODO Auto-generated catch block
				e1.printStackTrace();
			}
		});
		btnEdit.setOpaque(true);
		btnEdit.setForeground(Color.WHITE);
		btnEdit.setFocusPainted(false);
		btnEdit.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnEdit.setBackground(new Color(94, 109, 126));
		btnEdit.setBounds(600, 97, 120, 45);
		panel.add(btnEdit);
		
		JButton btnSlet = new JButton("Slet Ordre");
		btnSlet.addActionListener((e) -> {
				try {
					deleteOrder();
				} catch (SQLException e1) {
					// TODO Auto-generated catch block
					e1.printStackTrace();
				}
		});
		btnSlet.setOpaque(true);
		btnSlet.setForeground(Color.WHITE);
		btnSlet.setFocusPainted(false);
		btnSlet.setBorder(new LineBorder(new Color(85,85,85), 1));
		btnSlet.setBackground(new Color(174, 79, 79));
		btnSlet.setBounds(600, 179, 120, 45);
		panel.add(btnSlet);
		
		init();
	}
	
public void init() throws SQLException {
	lstOrders.setCellRenderer(new OrderListRenderer());
	updateOrderList();
}

public void updateOrderList() throws SQLException {
	List<Order> ppl = oCtr.getAllOrders();
	DefaultListModel<Order> dlm = new DefaultListModel<>();
	for(int i = 0 ; i < ppl.size(); i++) {
		dlm.addElement(ppl.get(i));
	}
	this.lstOrders.setModel(dlm);
}

public void showOrder() throws SQLException, ParseException {
	Order o = lstOrders.getSelectedValue();
	if(o != null) {
		ViewOrder ow = new ViewOrder();
		ow.setOrder(o);
		ow.setVisible(true);
		updateOrderList();
		ow.buttonView(1);
	}
	else{
		JOptionPane.showMessageDialog(null, "Der blev ikke valgt en Ordre!", "Fejl!", JOptionPane.ERROR_MESSAGE);
	}
}

public void deleteOrder() throws SQLException{
	if(lstOrders.getSelectedValue() != null){
		oCtr.deleteOrder(lstOrders.getSelectedValue().getId());
		JOptionPane.showMessageDialog(null, "En Ordre blev slettet!");
		init();
	}
	else{
		JOptionPane.showMessageDialog(null, "Der blev ikke valgt en Ordre!", "Fejl!", JOptionPane.ERROR_MESSAGE);
	}
}
	
	public JPanel getOrdrePanel()
	{
		return contentPane;
	}
}
