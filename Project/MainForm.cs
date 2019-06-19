using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Record;

namespace Project {
	public class MainForm:Form {
		private Image loadingPic=global::Project.Properties.Resources.loading;
		private Image recordPic_normal;
		private Image recordPic_on;
		private Image recordPic_hover;
		private Image topBarBackground;
		private Image pianoBackground;
		private Label controlBar;
		private Label recordButton;
		private bool recording=false;
		private int width;      
		private int height;
		private KeyBoard kb;
		private Record.Record rc=new Record.Record();
		private int keyDown_key=0;
		private Form loadin=new Form();
		private Label open=new Label();
		private Label newFile=new Label();
		private Label save=new Label();
		private Label exit=new Label();
		public MainForm() {
			loadin.Size=new Size(450, 300);
			loadin.TopMost=true;
			loadin.Location= new Point(0,0);
			loadin.FormBorderStyle=FormBorderStyle.None;
			loadin.BackgroundImageLayout=ImageLayout.Stretch;
			loadin.BackgroundImage=loadingPic;
			loadin.Visible=true;
			loadIn();
			initialForm();
			initialPiano();
			
			width=Screen.PrimaryScreen.Bounds.Width;
			height=Screen.PrimaryScreen.Bounds.Height;

			kb=new KeyBoard(rc);
			kb.Location=new Point(0, height*3/4-25);
			kb.Size=new Size(width, height/4+25);
			this.Controls.Add(kb);

			controlBar=new Label();
			controlBar.Size=new Size(width, 24);
			controlBar.Location=new Point(0, 0);
			controlBar.BackgroundImageLayout=ImageLayout.Stretch;
			controlBar.BackgroundImage=topBarBackground;
			this.Controls.Add(controlBar);
			
			recordButton=new Label();
			recordButton.Size=new Size(30, 24);
			recordButton.Location=new Point(width/4, 0);
			recordButton.BackgroundImage=recordPic_normal;
			recordButton.BackgroundImageLayout=ImageLayout.Stretch;
			recordButton.MouseEnter+=recordButton_MouseEnter;
			recordButton.MouseLeave+=recordButton_MouseLeave;
			recordButton.MouseClick+=recordButton_MouseClick;
			controlBar.Controls.Add(recordButton);

			open.Text="開啟舊檔";
			open.ForeColor=Color.White;
			open.BackgroundImageLayout=ImageLayout.Stretch;
			open.BackgroundImage=topBarBackground;
			open.Size=new Size(60, 24);
			open.Location=new Point(70, 0);
			open.Click+=open_Click;
			controlBar.Controls.Add(open);

			newFile.Text="開啟新檔";
			newFile.ForeColor=Color.White;
			newFile.BackgroundImageLayout=ImageLayout.Stretch;
			newFile.BackgroundImage=topBarBackground;
			newFile.Size=new Size(60, 24);
			newFile.Location=new Point(10, 0);
			newFile.Click+=newFile_Click;
			controlBar.Controls.Add(newFile);

			save.Text="儲存檔案";
			save.ForeColor=Color.White;
			save.BackgroundImageLayout=ImageLayout.Stretch;
			save.BackgroundImage=topBarBackground;
			save.Size=new Size(60, 24);
			save.Location=new Point(130, 0);
			save.Click+=save_Click;
			controlBar.Controls.Add(save);

			exit.Text="離開";
			exit.ForeColor=Color.White;
			exit.BackgroundImageLayout=ImageLayout.Stretch;
			exit.BackgroundImage=topBarBackground;
			exit.Size=new Size(30, 24);
			exit.Location=new Point(width-30, 0);
			exit.Click+=exit_Click;
			controlBar.Controls.Add(exit);

			rc.Size=new Size(width/2, height*3/4-55);
			rc.Location=new Point(width/4, 24);
			this.Controls.Add(rc);

			this.KeyDown+=MainForm_KeyDown;
			this.KeyUp+=MainForm_KeyUp;
			loadin.Visible=false;
		}

		private void exit_Click(object sender, EventArgs e) {
			this.Close();
			Environment.Exit(Environment.ExitCode);
		}
		
		void save_Click(object sender, EventArgs e) {
			rc.save();
		}

		void open_Click(object sender, EventArgs e) {
			rc.load();
		}

		void newFile_Click(object sender, EventArgs e) {
			rc.clear();
		}
		void recordButton_MouseClick(object sender, MouseEventArgs e) {
			if(recording){
				rc.stop_now();
				recording=false;
				recordButton.BackgroundImage=recordPic_hover;
			}else{
				recording=true;
				rc.start_now();
				recordButton.BackgroundImage=recordPic_on;
			}

		}

		void recordButton_MouseLeave(object sender, EventArgs e) {
			if(!recording)
				recordButton.BackgroundImage=recordPic_normal;
		}

		void recordButton_MouseEnter(object sender, EventArgs e){
			if(!recording)
				recordButton.BackgroundImage=recordPic_hover;
		}

		void MainForm_KeyDown(object sender, KeyEventArgs e) {
			switch(e.KeyCode){
				case Keys.Z:
					kb.keys[15+12*keyDown_key].keyboardDown();
					break;
				case Keys.S:
					kb.keys[16+12*keyDown_key].keyboardDown();
					break;
				case Keys.X:
					kb.keys[17+12*keyDown_key].keyboardDown();
					break;
				case Keys.D:
					kb.keys[18+12*keyDown_key].keyboardDown();
					break;
				case Keys.C:
					kb.keys[19+12*keyDown_key].keyboardDown();
					break;
				case Keys.V:
					kb.keys[20+12*keyDown_key].keyboardDown();
					break;
				case Keys.G:
					kb.keys[21+12*keyDown_key].keyboardDown();
				break;
				case Keys.B:
					kb.keys[22+12*keyDown_key].keyboardDown();
				break;
				case Keys.H:
					kb.keys[23+12*keyDown_key].keyboardDown();
				break;
				case Keys.N:
					kb.keys[24+12*keyDown_key].keyboardDown();
				break;
				case Keys.J:
					kb.keys[25+12*keyDown_key].keyboardDown();
				break;
				case Keys.M:
					kb.keys[26+12*keyDown_key].keyboardDown();
				break;
				case Keys.Oemcomma:
					kb.keys[27+12*keyDown_key].keyboardDown();
				break;
				case Keys.Q:
					kb.keys[27+12*keyDown_key].keyboardDown();
				break;
				case Keys.D2:
					kb.keys[28+12*keyDown_key].keyboardDown();
				break;
				case Keys.W:
					kb.keys[29+12*keyDown_key].keyboardDown();
				break;
				case Keys.D3:
					kb.keys[30+12*keyDown_key].keyboardDown();
				break;
				case Keys.E:
					kb.keys[31+12*keyDown_key].keyboardDown();
				break;
				case Keys.R:
					kb.keys[32+12*keyDown_key].keyboardDown();
				break;
				case Keys.D5:
					kb.keys[33+12*keyDown_key].keyboardDown();
				break;
				case Keys.T:
					kb.keys[34+12*keyDown_key].keyboardDown();
				break;
				case Keys.D6:
					kb.keys[35+12*keyDown_key].keyboardDown();
				break;
				case Keys.Y:
					kb.keys[36+12*keyDown_key].keyboardDown();
				break;
				case Keys.D7:
					kb.keys[37+12*keyDown_key].keyboardDown();
				break;
				case Keys.U:
					kb.keys[38+12*keyDown_key].keyboardDown();
				break;
				case Keys.I:
					kb.keys[39+12*keyDown_key].keyboardDown();
				break;
				case Keys.Right:
					keyDown_key++;
					if(keyDown_key>4)	keyDown_key=4;
				break;
				case Keys.Left:
				keyDown_key--;
				if(keyDown_key<-1) keyDown_key=-1;
				break;
			}
		}
		void MainForm_KeyUp(object sender, KeyEventArgs e) {
			switch(e.KeyCode) {
				case Keys.Z:
					kb.keys[15+12*keyDown_key].keyboardUp();
					break;
				case Keys.S:
					kb.keys[16+12*keyDown_key].keyboardUp();
					break;
				case Keys.X:
					kb.keys[17+12*keyDown_key].keyboardUp();
					break;
				case Keys.D:
					kb.keys[18+12*keyDown_key].keyboardUp();
					break;
				case Keys.C:
					kb.keys[19+12*keyDown_key].keyboardUp();
					break;
				case Keys.V:
					kb.keys[20+12*keyDown_key].keyboardUp();
					break;
				case Keys.G:
					kb.keys[21+12*keyDown_key].keyboardUp();
					break;
				case Keys.B:
					kb.keys[22+12*keyDown_key].keyboardUp();
					break;
				case Keys.H:
					kb.keys[23+12*keyDown_key].keyboardUp();
					break;
				case Keys.N:
					kb.keys[24+12*keyDown_key].keyboardUp();
					break;
				case Keys.J:
					kb.keys[25+12*keyDown_key].keyboardUp();
					break;
				case Keys.M:
					kb.keys[26+12*keyDown_key].keyboardUp();
					break;
				case Keys.Oemcomma:
					kb.keys[27+12*keyDown_key].keyboardUp();
					break;
				case Keys.Q:
					kb.keys[27+12*keyDown_key].keyboardUp();
					break;
				case Keys.D2:
					kb.keys[28+12*keyDown_key].keyboardUp();
					break;
				case Keys.W:
					kb.keys[29+12*keyDown_key].keyboardUp();
					break;
				case Keys.D3:
					kb.keys[30+12*keyDown_key].keyboardUp();
					break;
				case Keys.E:
					kb.keys[31+12*keyDown_key].keyboardUp();
					break;
				case Keys.R:
					kb.keys[32+12*keyDown_key].keyboardUp();
					break;
				case Keys.D5:
					kb.keys[33+12*keyDown_key].keyboardUp();
					break;
				case Keys.T:
					kb.keys[34+12*keyDown_key].keyboardUp();
					break;
				case Keys.D6:
					kb.keys[35+12*keyDown_key].keyboardUp();
					break;
				case Keys.Y:
					kb.keys[36+12*keyDown_key].keyboardUp();
					break;
				case Keys.D7:
					kb.keys[37+12*keyDown_key].keyboardUp();
					break;
				case Keys.U:
					kb.keys[38+12*keyDown_key].keyboardUp();
					break;
				case Keys.I:
					kb.keys[39+12*keyDown_key].keyboardUp();
					break;
			}
		}
		private void loadIn(){
			pianoBackground=global::Project.Properties.Resources.pianoBackground;
			topBarBackground=global::Project.Properties.Resources.topBar;
			recordPic_hover=global::Project.Properties.Resources.recordPic_hover;
			recordPic_normal=global::Project.Properties.Resources.recordPic_normal;
			recordPic_on=global::Project.Properties.Resources.recordPic_on;
			KeyPanel.loadIn();
		}
		private void initialForm() {
			this.FormBorderStyle=FormBorderStyle.None;
			this.BackgroundImageLayout=ImageLayout.Stretch;
			this.WindowState=FormWindowState.Maximized;
		}
		private void initialPiano(){
			paintPiano();
		}

		private void paintPiano(){
			this.BackgroundImage=pianoBackground;
		}

		private void InitializeComponent() {
			this.SuspendLayout();
			// 
			// MainForm
			// 
			this.ClientSize = new System.Drawing.Size(384, 345);
			this.Name = "MainForm";
			this.ResumeLayout(false);

		}
	}
}