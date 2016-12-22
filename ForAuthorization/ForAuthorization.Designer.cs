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
            this.Name_TextBox = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.TextBox_NewAuthorizedSerial = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.TextBox_NewAuthorizedKeyCode = new System.Windows.Forms.TextBox();
            this.CB_WriteToFile = new System.Windows.Forms.CheckBox();
            this.Single = new System.Windows.Forms.Button();
            this.Multiple = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.Notice = new System.Windows.Forms.Label();
            this.BTN_OneToDB = new System.Windows.Forms.Button();
            this.BTN_MulToDB = new System.Windows.Forms.Button();
            this.BTN_Previous = new System.Windows.Forms.Button();
            this.BTN_Next = new System.Windows.Forms.Button();
            this.BTN_Clear = new System.Windows.Forms.Button();
            this.LB_CurrentNUM = new System.Windows.Forms.Label();
            this.LB_AllCount = new System.Windows.Forms.Label();
            this.LB_Depart = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // Name_TextBox
            // 
            this.Name_TextBox.Location = new System.Drawing.Point(86, 25);
            this.Name_TextBox.Name = "Name_TextBox";
            this.Name_TextBox.Size = new System.Drawing.Size(172, 21);
            this.Name_TextBox.TabIndex = 0;
            this.Name_TextBox.Text = "Everyone";
            this.Name_TextBox.Click += new System.EventHandler(this.TB_Change_Click);
            this.Name_TextBox.TextChanged += new System.EventHandler(this.Name_TextBox_TextChanged);
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
            // TextBox_NewAuthorizedSerial
            // 
            this.TextBox_NewAuthorizedSerial.Location = new System.Drawing.Point(86, 55);
            this.TextBox_NewAuthorizedSerial.Name = "TextBox_NewAuthorizedSerial";
            this.TextBox_NewAuthorizedSerial.ReadOnly = true;
            this.TextBox_NewAuthorizedSerial.Size = new System.Drawing.Size(611, 21);
            this.TextBox_NewAuthorizedSerial.TabIndex = 3;
            this.TextBox_NewAuthorizedSerial.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
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
            // TextBox_NewAuthorizedKeyCode
            // 
            this.TextBox_NewAuthorizedKeyCode.Location = new System.Drawing.Point(86, 85);
            this.TextBox_NewAuthorizedKeyCode.Name = "TextBox_NewAuthorizedKeyCode";
            this.TextBox_NewAuthorizedKeyCode.ReadOnly = true;
            this.TextBox_NewAuthorizedKeyCode.Size = new System.Drawing.Size(207, 21);
            this.TextBox_NewAuthorizedKeyCode.TabIndex = 5;
            this.TextBox_NewAuthorizedKeyCode.TextAlign = System.Windows.Forms.HorizontalAlignment.Center;
            // 
            // CB_WriteToFile
            // 
            this.CB_WriteToFile.AutoSize = true;
            this.CB_WriteToFile.Location = new System.Drawing.Point(274, 27);
            this.CB_WriteToFile.Name = "CB_WriteToFile";
            this.CB_WriteToFile.Size = new System.Drawing.Size(72, 16);
            this.CB_WriteToFile.TabIndex = 6;
            this.CB_WriteToFile.Text = "写入文件";
            this.CB_WriteToFile.UseVisualStyleBackColor = true;
            // 
            // Single
            // 
            this.Single.Location = new System.Drawing.Point(352, 24);
            this.Single.Name = "Single";
            this.Single.Size = new System.Drawing.Size(75, 23);
            this.Single.TabIndex = 7;
            this.Single.Text = "生成单个";
            this.Single.UseVisualStyleBackColor = true;
            this.Single.Click += new System.EventHandler(this.Single_Click);
            // 
            // Multiple
            // 
            this.Multiple.Location = new System.Drawing.Point(442, 24);
            this.Multiple.Name = "Multiple";
            this.Multiple.Size = new System.Drawing.Size(75, 23);
            this.Multiple.TabIndex = 8;
            this.Multiple.Text = "批量生成";
            this.Multiple.UseVisualStyleBackColor = true;
            this.Multiple.Click += new System.EventHandler(this.Multiple_Click);
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
            this.Notice.Size = new System.Drawing.Size(299, 12);
            this.Notice.TabIndex = 10;
            this.Notice.Text = "这里显示相关动作的说明,看仔细了,出事了别怪我没说!";
            // 
            // BTN_OneToDB
            // 
            this.BTN_OneToDB.Enabled = false;
            this.BTN_OneToDB.Location = new System.Drawing.Point(532, 24);
            this.BTN_OneToDB.Name = "BTN_OneToDB";
            this.BTN_OneToDB.Size = new System.Drawing.Size(75, 23);
            this.BTN_OneToDB.TabIndex = 11;
            this.BTN_OneToDB.Text = "单条入库";
            this.BTN_OneToDB.UseVisualStyleBackColor = true;
            this.BTN_OneToDB.Click += new System.EventHandler(this.BTN_OneToDB_Click);
            // 
            // BTN_MulToDB
            // 
            this.BTN_MulToDB.Enabled = false;
            this.BTN_MulToDB.Location = new System.Drawing.Point(622, 24);
            this.BTN_MulToDB.Name = "BTN_MulToDB";
            this.BTN_MulToDB.Size = new System.Drawing.Size(75, 23);
            this.BTN_MulToDB.TabIndex = 12;
            this.BTN_MulToDB.Text = "批量入库";
            this.BTN_MulToDB.UseVisualStyleBackColor = true;
            this.BTN_MulToDB.Click += new System.EventHandler(this.BTN_MulToDB_Click);
            // 
            // BTN_Previous
            // 
            this.BTN_Previous.Enabled = false;
            this.BTN_Previous.Location = new System.Drawing.Point(442, 85);
            this.BTN_Previous.Name = "BTN_Previous";
            this.BTN_Previous.Size = new System.Drawing.Size(75, 23);
            this.BTN_Previous.TabIndex = 13;
            this.BTN_Previous.Text = "上一个";
            this.BTN_Previous.UseVisualStyleBackColor = true;
            this.BTN_Previous.Click += new System.EventHandler(this.BTN_Previous_Click);
            // 
            // BTN_Next
            // 
            this.BTN_Next.Enabled = false;
            this.BTN_Next.Location = new System.Drawing.Point(532, 85);
            this.BTN_Next.Name = "BTN_Next";
            this.BTN_Next.Size = new System.Drawing.Size(75, 23);
            this.BTN_Next.TabIndex = 14;
            this.BTN_Next.Text = "下一个";
            this.BTN_Next.UseVisualStyleBackColor = true;
            this.BTN_Next.Click += new System.EventHandler(this.BTN_Next_Click);
            // 
            // BTN_Clear
            // 
            this.BTN_Clear.Enabled = false;
            this.BTN_Clear.Location = new System.Drawing.Point(622, 85);
            this.BTN_Clear.Name = "BTN_Clear";
            this.BTN_Clear.Size = new System.Drawing.Size(75, 23);
            this.BTN_Clear.TabIndex = 15;
            this.BTN_Clear.Text = "清空";
            this.BTN_Clear.UseVisualStyleBackColor = true;
            this.BTN_Clear.Click += new System.EventHandler(this.BTN_Clear_Click);
            // 
            // LB_CurrentNUM
            // 
            this.LB_CurrentNUM.AutoSize = true;
            this.LB_CurrentNUM.Font = new System.Drawing.Font("宋体", 12F);
            this.LB_CurrentNUM.Location = new System.Drawing.Point(319, 88);
            this.LB_CurrentNUM.Name = "LB_CurrentNUM";
            this.LB_CurrentNUM.Size = new System.Drawing.Size(32, 16);
            this.LB_CurrentNUM.TabIndex = 16;
            this.LB_CurrentNUM.Text = "NUM";
            this.LB_CurrentNUM.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_AllCount
            // 
            this.LB_AllCount.AutoSize = true;
            this.LB_AllCount.Font = new System.Drawing.Font("宋体", 12F);
            this.LB_AllCount.Location = new System.Drawing.Point(386, 88);
            this.LB_AllCount.Name = "LB_AllCount";
            this.LB_AllCount.Size = new System.Drawing.Size(48, 16);
            this.LB_AllCount.TabIndex = 17;
            this.LB_AllCount.Text = "Count";
            this.LB_AllCount.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // LB_Depart
            // 
            this.LB_Depart.AutoSize = true;
            this.LB_Depart.Font = new System.Drawing.Font("宋体", 12F);
            this.LB_Depart.Location = new System.Drawing.Point(358, 88);
            this.LB_Depart.Name = "LB_Depart";
            this.LB_Depart.Size = new System.Drawing.Size(16, 16);
            this.LB_Depart.TabIndex = 18;
            this.LB_Depart.Text = "/";
            this.LB_Depart.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ForAuthorization
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(709, 158);
            this.Controls.Add(this.LB_Depart);
            this.Controls.Add(this.LB_AllCount);
            this.Controls.Add(this.LB_CurrentNUM);
            this.Controls.Add(this.BTN_Clear);
            this.Controls.Add(this.BTN_Next);
            this.Controls.Add(this.BTN_Previous);
            this.Controls.Add(this.BTN_MulToDB);
            this.Controls.Add(this.BTN_OneToDB);
            this.Controls.Add(this.Notice);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.Multiple);
            this.Controls.Add(this.Single);
            this.Controls.Add(this.CB_WriteToFile);
            this.Controls.Add(this.TextBox_NewAuthorizedKeyCode);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.TextBox_NewAuthorizedSerial);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Name_TextBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "ForAuthorization";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "授权序列及授权码生成器";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox Name_TextBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox TextBox_NewAuthorizedSerial;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox TextBox_NewAuthorizedKeyCode;
        private System.Windows.Forms.CheckBox CB_WriteToFile;
        private System.Windows.Forms.Button Single;
        private System.Windows.Forms.Button Multiple;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label Notice;

        private void textBox1_TextChanged(object sender)
        {
            if (System.Text.RegularExpressions.Regex.IsMatch("^[a-zA-Z]", Name_TextBox.Text))
            {
                Name_TextBox.Text.Remove(Name_TextBox.Text.Length - 1);
            }
        }

        private System.Windows.Forms.Button BTN_OneToDB;
        private System.Windows.Forms.Button BTN_MulToDB;
        private System.Windows.Forms.Button BTN_Previous;
        private System.Windows.Forms.Button BTN_Next;
        private System.Windows.Forms.Button BTN_Clear;
        private System.Windows.Forms.Label LB_CurrentNUM;
        private System.Windows.Forms.Label LB_AllCount;
        private System.Windows.Forms.Label LB_Depart;
    }
}

