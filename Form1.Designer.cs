namespace PIMIII
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            txtInput = new TextBox();
            btnSend = new Button();
            rtbChat = new RichTextBox();
            label1 = new Label();
            label2 = new Label();
            SuspendLayout();
            // 
            // txtInput
            // 
            txtInput.Location = new Point(12, 77);
            txtInput.Name = "txtInput";
            txtInput.Size = new Size(776, 27);
            txtInput.TabIndex = 0;
            // 
            // btnSend
            // 
            btnSend.Location = new Point(12, 110);
            btnSend.Name = "btnSend";
            btnSend.Size = new Size(94, 29);
            btnSend.TabIndex = 1;
            btnSend.Text = "OK";
            btnSend.UseVisualStyleBackColor = true;
            btnSend.Click += btnSend_Click;
            btnSend.Enter += btnSend_Click;
            // 
            // rtbChat
            // 
            rtbChat.Location = new Point(12, 163);
            rtbChat.Name = "rtbChat";
            rtbChat.Size = new Size(776, 275);
            rtbChat.TabIndex = 2;
            rtbChat.Text = "";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(12, 9);
            label1.Name = "label1";
            label1.Size = new Size(338, 20);
            label1.TabIndex = 3;
            label1.Text = "Aplicativo de suporte de T.I. integrado com I.A.";
            label1.Click += label1_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 54);
            label2.Name = "label2";
            label2.Size = new Size(177, 20);
            label2.TabIndex = 4;
            label2.Text = "Digite sua dúvida abaixo:";
            // 
            // Form1
            // 
            AcceptButton = btnSend;
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.Azure;
            ClientSize = new Size(800, 450);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(rtbChat);
            Controls.Add(btnSend);
            Controls.Add(txtInput);
            Name = "Form1";
            Text = "Axis Tecnology";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox txtInput;
        private Button btnSend;
        private RichTextBox rtbChat;
        private Label label1;
        private Label label2;
    }
}
