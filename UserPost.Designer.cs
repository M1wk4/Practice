
namespace WindowsFormsApp2
{
	partial class UserPost
	{
		/// <summary>
		/// Required designer variable.
		/// </summary>
		private System.ComponentModel.IContainer components = null;

		/// <summary>
		/// Clean up any resources being used.
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
		/// Required method for Designer support - do not modify
		/// the contents of this method with the code editor.
		/// </summary>
		private void InitializeComponent()
		{
			System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UserPost));
			this.SuspendLayout();
			// 
			// UserPost
			// 
			this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
			this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
			this.BackgroundImage = global::WindowsFormsApp2.Properties.Resources.BGAuthForm;
			this.ClientSize = new System.Drawing.Size(724, 361);
			this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
			this.MaximumSize = new System.Drawing.Size(740, 400);
			this.MinimumSize = new System.Drawing.Size(740, 400);
			this.Name = "UserPost";
			this.Text = "UserPost";
			this.Load += new System.EventHandler(this.UserPost_Load);
			this.ResumeLayout(false);

		}

		#endregion
	}
}