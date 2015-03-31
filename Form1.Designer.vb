<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Me.Box = New System.Windows.Forms.PictureBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.LScore = New System.Windows.Forms.Label
        Me.TimerGameOver = New System.Windows.Forms.Timer(Me.components)
        Me.BNewGame = New System.Windows.Forms.Button
        CType(Me.Box, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'Box
        '
        Me.Box.Location = New System.Drawing.Point(12, 36)
        Me.Box.Name = "Box"
        Me.Box.Size = New System.Drawing.Size(406, 406)
        Me.Box.TabIndex = 0
        Me.Box.TabStop = False
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(370, 12)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(13, 13)
        Me.Label1.TabIndex = 1
        Me.Label1.Text = "x"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(405, 12)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(13, 13)
        Me.Label2.TabIndex = 2
        Me.Label2.Text = "y"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(290, 12)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(23, 13)
        Me.Label3.TabIndex = 3
        Me.Label3.Text = "Sqr"
        '
        'LScore
        '
        Me.LScore.AutoSize = True
        Me.LScore.Location = New System.Drawing.Point(13, 12)
        Me.LScore.Name = "LScore"
        Me.LScore.Size = New System.Drawing.Size(47, 13)
        Me.LScore.TabIndex = 5
        Me.LScore.Text = "Score: 0"
        '
        'TimerGameOver
        '
        Me.TimerGameOver.Enabled = True
        '
        'BNewGame
        '
        Me.BNewGame.Location = New System.Drawing.Point(171, 7)
        Me.BNewGame.Name = "BNewGame"
        Me.BNewGame.Size = New System.Drawing.Size(75, 23)
        Me.BNewGame.TabIndex = 6
        Me.BNewGame.Text = "New Game"
        Me.BNewGame.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoValidate = System.Windows.Forms.AutoValidate.EnablePreventFocusChange
        Me.ClientSize = New System.Drawing.Size(432, 454)
        Me.Controls.Add(Me.BNewGame)
        Me.Controls.Add(Me.LScore)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.Box)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Lines"
        CType(Me.Box, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents Box As System.Windows.Forms.PictureBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents LScore As System.Windows.Forms.Label
    Friend WithEvents TimerGameOver As System.Windows.Forms.Timer
    Friend WithEvents BNewGame As System.Windows.Forms.Button

End Class
