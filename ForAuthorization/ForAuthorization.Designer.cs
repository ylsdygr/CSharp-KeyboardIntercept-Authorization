namespace ForAuthorization
{
    partial class ForAuthorization
    {
        /// <summary>
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            this.MaximizeBox = false;
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_NewAuthorizedString = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_NewAuthorizedKey = new System.Windows.Forms.TextBox();
            this.checkBox1 = new System.Windows.Forms.CheckBox();
            this.Single = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Notice = new System.Windows.Forms.Label();
            this.BTN_CopyNewString = new System.Windows.Forms.Button();
            this.BTN_CopyKey = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.Location = new System.Drawing.Point(86, 25);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(172, 21);
            this.Name_TextBox.TabIndex = 0;
            this.Name_TextBox.TextChanged += new System.EventHandler(this.Name_TextBox_TextChanged);
            //this.Name_TextBox.ImeMode = System.Windows.Forms.ImeMode.Alpha;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(16, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "姓    名：";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(16, 59);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(65, 12);
            this.label2.TabIndex = 2;
            this.label2.Text = "授权序列：";
            // 
            // TextBox_NewAuthorizedString
            // 
            this.TextBox_NewAuthorizedString.Enabled = false;
            this.TextBox_NewAuthorizedString.Location = new System.Drawing.Point(86, 55);
            this.TextBox_NewAuthorizedString.Name = "TextBox_NewAuthorizedString";
            this.TextBox_NewAuthorizedString.Size = new System.Drawing.Size(611, 21);
            this.TextBox_NewAuthorizedString.TabIndex = 3;
            this.TextBox_NewAuthorizedString.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(16, 89);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(65, 12);
            this.label3.TabIndex = 4;
            this.label3.Text = "授权密码：";
            // 
            // TextBox_NewAuthorizedKey
            // 
            this.TextBox_NewAuthorizedKey.Enabled = false;
            this.TextBox_NewAuthorizedKey.Location = new System.Drawing.Point(86, 85);
            this.TextBox_NewAuthorizedKey.Name = "TextBox_NewAuthorizedKey";
            this.TextBox_NewAuthorizedKey.Size = new System.Drawing.Size(207, 21);
            this.TextBox_NewAuthorizedKey.TabIndex = 5;
            this.TextBox_NewAuthorizedKey.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // checkBox1
            // 
            this.checkBox1.AutoSize = true;
            this.checkBox1.Location = new System.Drawing.Point(274, 27);
            this.checkBox1.Name = "checkBox1";
            this.checkBox1.Size = new System.Drawing.Size(72, 16);
            this.checkBox1.TabIndex = 6;
            this.checkBox1.Text = "写入文件";
            this.checkBox1.UseVisualStyleBackColor = true;
            // 
            // Single
            // 
            this.Single.Location = new System.Drawing.Point(362, 24);
            this.Single.Name = "Single";
            this.Single.Size = new System.Drawing.Size(75, 23);
            this.Single.TabIndex = 7;
            this.Single.Text = "生成单个";
            this.Single.UseVisualStyleBackColor = true;
            this.Single.Click += new System.EventHandler(this.Single_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(454, 24);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(75, 23);
            this.button2.TabIndex = 8;
            this.button2.Text = "批量生成";
            this.button2.UseVisualStyleBackColor = true;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(16, 119);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(65, 12);
            this.label4.TabIndex = 9;
            this.label4.Text = "说    明：";
            // 
            // Notice
            // 
            this.Notice.AutoSize = true;
            this.Notice.Location = new System.Drawing.Point(84, 119);
            this.Notice.Name = "Notice";
            this.Notice.Size = new System.Drawing.Size(137, 12);
            this.Notice.TabIndex = 10;
            this.Notice.Text = "这里显示相关动作的说明";
            // 
            // BTN_CopyNewString
            // 
            this.BTN_CopyNewString.Location = new System.Drawing.Point(535, 24);
            this.BTN_CopyNewString.Name = "BTN_CopyNewString";
            this.BTN_CopyNewString.Size = new System.Drawing.Size(75, 23);
            this.BTN_CopyNewString.TabIndex = 11;
            this.BTN_CopyNewString.Text = "复制序列";
            this.BTN_CopyNewString.UseVisualStyleBackColor = true;
            this.BTN_CopyNewString.Click += new System.EventHandler(this.BTN_CopyNewString_Click);
            // 
            // BTN_CopyKey
            // 
            this.BTN_CopyKey.Location = new System.Drawing.Point(614, 24);
            this.BTN_CopyKey.Name = "BTN_CopyKey";
            this.BTN_CopyKey.Size = new System.Drawing.Size(75, 23);
            this.BTN_CopyKey.TabIndex = 12;
            this.BTN_CopyKey.Text = "复制密码";
            this.BTN_CopyKey.UseVisualStyleBackColor = true;
            this.BTN_CopyKey.Click += new System.EventHandler(this.BTN_CopyKey_Click);
            // 
            // ForAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 185);
            this.Controls.Add(this.BTN_CopyKey);
            this.Controls.Add(this.BTN_CopyNewString);
            this.Controls.Add(this.Notice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.Single);
            this.Controls.Add(this.checkBox1);
            this.Controls.Add(this.TextBox_NewAuthorizedKey);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_NewAuthorizedString);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Name_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "ForAuthorization";
            this.Text = "授权序列及授权码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_NewAuthorizedString;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_NewAuthorizedKey;
        private System.Windows.Forms.CheckBox checkBox1;
        private System.Windows.Forms.Button Single;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Notice;

        private void textBox1_TextChanged(object sender)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", Name_TextBox.Text))
            {
                Name_TextBox.Text.Remove(Name_TextBox.Text.Length - 1);
            }
        }

        private System.Windows.Forms.Button BTN_CopyNewString;
        private System.Windows.Forms.Button BTN_CopyKey;
    }
}

