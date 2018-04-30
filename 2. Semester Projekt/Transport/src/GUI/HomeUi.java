package GUI;

import java.awt.BorderLayout;
import java.awt.EventQueue;

import javax.swing.JFrame;
import javax.swing.JPanel;
import javax.swing.border.EmptyBorder;
import javax.swing.JLabel;
import java.awt.Font;
import java.awt.Color;

public class HomeUi extends JFrame {

	private JPanel contentPane;

	/**
	 * Launch the application.
	 */
	public static void main(String[] args) {
		EventQueue.invokeLater(new Runnable() {
			public void run() {
				try {
					HomeUi frame = new HomeUi();
					frame.setVisible(true);
				} catch (Exception e) {
					e.printStackTrace();
				}
			}
		});
	}

	/**
	 * Create the frame.
	 */
	public HomeUi() {
		setDefaultCloseOperation(JFrame.EXIT_ON_CLOSE);
		setBounds(100, 100, 744, 441);
		contentPane = new JPanel();
		contentPane.setBackground(new Color(227, 225, 224));
		contentPane.setBorder(new EmptyBorder(5, 5, 5, 5));
		setContentPane(contentPane);
		contentPane.setLayout(null);
		
		JLabel lblCharlieJensenTransport = new JLabel("Charlie Jensen Transport");
		lblCharlieJensenTransport.setForeground(new Color(0, 51, 0));
		lblCharlieJensenTransport.setFont(new Font("Comic Sans MS", Font.BOLD, 30));
		lblCharlieJensenTransport.setBounds(47, 38, 477, 48);
		contentPane.add(lblCharlieJensenTransport);
		
		JLabel lblInternationalKlsefrysetransport = new JLabel("International K\u00F8le-frysetransport");
		lblInternationalKlsefrysetransport.setFont(new Font("Verdana", Font.BOLD | Font.ITALIC, 20));
		lblInternationalKlsefrysetransport.setBounds(128, 70, 487, 62);
		contentPane.add(lblInternationalKlsefrysetransport);
	}
	
	public JPanel getHomePanel()
	{
		return contentPane;
	}

}
