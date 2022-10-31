namespace JoshuaBradshaw.ContactManager.UI
{
    partial class ContactForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose ( bool disposing )
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent ()
        {
            this.components = new System.ComponentModel.Container();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this._textFirstName = new System.Windows.Forms.TextBox();
            this._textLastName = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this._checkIsFavorite = new System.Windows.Forms.CheckBox();
            this._textEmail = new System.Windows.Forms.TextBox();
            this._textNotes = new System.Windows.Forms.TextBox();
            this._errors = new System.Windows.Forms.ErrorProvider(this.components);
            this._btnSave = new System.Windows.Forms.Button();
            this._btnCancel = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this._errors)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(32, 30);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(64, 15);
            this.label1.TabIndex = 0;
            this.label1.Text = "First Name";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(33, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(63, 15);
            this.label2.TabIndex = 1;
            this.label2.Text = "Last Name";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(60, 91);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(36, 15);
            this.label3.TabIndex = 2;
            this.label3.Text = "Email";
            // 
            // _textFirstName
            // 
            this._textFirstName.Location = new System.Drawing.Point(116, 27);
            this._textFirstName.Name = "_textFirstName";
            this._textFirstName.Size = new System.Drawing.Size(100, 23);
            this._textFirstName.TabIndex = 3;
            this._textFirstName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateFirstName);
            // 
            // _textLastName
            // 
            this._textLastName.Location = new System.Drawing.Point(116, 58);
            this._textLastName.Name = "_textLastName";
            this._textLastName.Size = new System.Drawing.Size(100, 23);
            this._textLastName.TabIndex = 4;
            this._textLastName.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateLastName);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(58, 127);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(38, 15);
            this.label4.TabIndex = 5;
            this.label4.Text = "Notes";
            // 
            // _checkIsFavorite
            // 
            this._checkIsFavorite.AutoSize = true;
            this._checkIsFavorite.Location = new System.Drawing.Point(116, 153);
            this._checkIsFavorite.Name = "_checkIsFavorite";
            this._checkIsFavorite.Size = new System.Drawing.Size(79, 19);
            this._checkIsFavorite.TabIndex = 6;
            this._checkIsFavorite.Text = "Is Favorite";
            this._checkIsFavorite.UseVisualStyleBackColor = true;
            // 
            // _textEmail
            // 
            this._textEmail.Location = new System.Drawing.Point(116, 91);
            this._textEmail.Name = "_textEmail";
            this._textEmail.Size = new System.Drawing.Size(100, 23);
            this._textEmail.TabIndex = 7;
            this._textEmail.Validating += new System.ComponentModel.CancelEventHandler(this.OnValidateEmail);
            // 
            // _textNotes
            // 
            this._textNotes.Location = new System.Drawing.Point(116, 124);
            this._textNotes.Name = "_textNotes";
            this._textNotes.Size = new System.Drawing.Size(100, 23);
            this._textNotes.TabIndex = 8;
            // 
            // _errors
            // 
            this._errors.BlinkStyle = System.Windows.Forms.ErrorBlinkStyle.NeverBlink;
            this._errors.ContainerControl = this;
            // 
            // _btnSave
            // 
            this._btnSave.Location = new System.Drawing.Point(116, 254);
            this._btnSave.Name = "_btnSave";
            this._btnSave.Size = new System.Drawing.Size(75, 23);
            this._btnSave.TabIndex = 9;
            this._btnSave.Text = "Save";
            this._btnSave.UseVisualStyleBackColor = true;
            this._btnSave.Click += new System.EventHandler(this.OnSave);
            // 
            // _btnCancel
            // 
            this._btnCancel.Location = new System.Drawing.Point(197, 254);
            this._btnCancel.Name = "_btnCancel";
            this._btnCancel.Size = new System.Drawing.Size(75, 23);
            this._btnCancel.TabIndex = 10;
            this._btnCancel.Text = "Cancel";
            this._btnCancel.UseVisualStyleBackColor = true;
            // 
            // ContactForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this._btnCancel);
            this.Controls.Add(this._btnSave);
            this.Controls.Add(this._textNotes);
            this.Controls.Add(this._textEmail);
            this.Controls.Add(this._checkIsFavorite);
            this.Controls.Add(this.label4);
            this.Controls.Add(this._textLastName);
            this.Controls.Add(this._textFirstName);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "ContactForm";
            this.Text = "ContactForm";
            ((System.ComponentModel.ISupportInitialize)(this._errors)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private TextBox _textFirstName;
        private TextBox _textLastName;
        private Label label4;
        private CheckBox _checkIsFavorite;
        private TextBox _textEmail;
        private TextBox _textNotes;
        private ErrorProvider _errors;
        private Button _btnCancel;
        private Button _btnSave;
    }
}