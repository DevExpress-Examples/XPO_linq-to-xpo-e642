' Developer Express Code Central Example:
' LINQ to XPO
' 
' LINQ is .NET Language-Integrated Query
' (http://msdn2.microsoft.com/en-us/library/bb308959.aspx). It's included in .NET
' Framework 3.5 and you can use it in Visual Studio 2008 projects.
' XPO officially
' supports LINQ since v7.3. This example provides several sample queries to help
' you get started with LINQ to XPO.
' See
' Also:
' http://www.devexpress.com/scid=K18051
' The LINQ project
' (http://msdn2.microsoft.com/en-us/netframework/aa904594.aspx)
' 
' You can find sample updates and versions for different programming languages here:
' http://www.devexpress.com/example=E642
Namespace XpoLinqNorthwindSample

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.textBox1 = New System.Windows.Forms.TextBox()
            Me.btnSelectWhere = New DevExpress.XtraEditors.SimpleButton()
            Me.simpleButton2 = New DevExpress.XtraEditors.SimpleButton()
            Me.panelControl1 = New DevExpress.XtraEditors.PanelControl()
            Me.btnAny = New DevExpress.XtraEditors.SimpleButton()
            Me.btnGroup = New DevExpress.XtraEditors.SimpleButton()
            Me.btnSelectTop = New DevExpress.XtraEditors.SimpleButton()
            Me.btnJoin = New DevExpress.XtraEditors.SimpleButton()
            Me.btnAggregates = New DevExpress.XtraEditors.SimpleButton()
            CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.panelControl1.SuspendLayout()
            Me.SuspendLayout()
            ' 
            ' textBox1
            ' 
            Me.textBox1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.textBox1.Location = New System.Drawing.Point(135, 0)
            Me.textBox1.Multiline = True
            Me.textBox1.Name = "textBox1"
            Me.textBox1.ScrollBars = System.Windows.Forms.ScrollBars.Both
            Me.textBox1.Size = New System.Drawing.Size(722, 487)
            Me.textBox1.TabIndex = 0
            Me.textBox1.WordWrap = False
            ' 
            ' btnSelectWhere
            ' 
            Me.btnSelectWhere.Location = New System.Drawing.Point(5, 34)
            Me.btnSelectWhere.Name = "btnSelectWhere"
            Me.btnSelectWhere.Size = New System.Drawing.Size(122, 23)
            Me.btnSelectWhere.TabIndex = 1
            Me.btnSelectWhere.Text = "&Select With 'Where'"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnSelectWhere.Click += new System.EventHandler(this.btnSelectWhere_Click)
'''  ' 
            ' simpleButton2
            ' 
Me.simpleButton2.Location = New System.Drawing.Point(5, 5)
            Me.simpleButton2.Name = "simpleButton2"
            Me.simpleButton2.Size = New System.Drawing.Size(122, 23)
            Me.simpleButton2.TabIndex = 2
            Me.simpleButton2.Text = "&Clear Log"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.simpleButton2.Click += new System.EventHandler(this.btnClear_Click)
'''  ' 
            ' panelControl1
            ' 
Me.panelControl1.Controls.Add(Me.btnAny)
            Me.panelControl1.Controls.Add(Me.btnGroup)
            Me.panelControl1.Controls.Add(Me.btnSelectTop)
            Me.panelControl1.Controls.Add(Me.btnJoin)
            Me.panelControl1.Controls.Add(Me.btnAggregates)
            Me.panelControl1.Controls.Add(Me.btnSelectWhere)
            Me.panelControl1.Controls.Add(Me.simpleButton2)
            Me.panelControl1.Dock = System.Windows.Forms.DockStyle.Left
            Me.panelControl1.Location = New System.Drawing.Point(0, 0)
            Me.panelControl1.Name = "panelControl1"
            Me.panelControl1.Size = New System.Drawing.Size(135, 487)
            Me.panelControl1.TabIndex = 3
            ' 
            ' btnAny
            ' 
            Me.btnAny.Location = New System.Drawing.Point(5, 182)
            Me.btnAny.Name = "btnAny"
            Me.btnAny.Size = New System.Drawing.Size(122, 23)
            Me.btnAny.TabIndex = 7
            Me.btnAny.Text = "Find An&y"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnAny.Click += new System.EventHandler(this.btnAny_Click)
'''  ' 
            ' btnGroup
            ' 
Me.btnGroup.Location = New System.Drawing.Point(5, 152)
            Me.btnGroup.Name = "btnGroup"
            Me.btnGroup.Size = New System.Drawing.Size(122, 23)
            Me.btnGroup.TabIndex = 6
            Me.btnGroup.Text = "&Group By"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnGroup.Click += new System.EventHandler(this.btnGroup_Click)
'''  ' 
            ' btnSelectTop
            ' 
Me.btnSelectTop.Location = New System.Drawing.Point(5, 63)
            Me.btnSelectTop.Name = "btnSelectTop"
            Me.btnSelectTop.Size = New System.Drawing.Size(122, 23)
            Me.btnSelectTop.TabIndex = 5
            Me.btnSelectTop.Text = "Select &Top 5"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnSelectTop.Click += new System.EventHandler(this.btnSelectTop_Click)
'''  ' 
            ' btnJoin
            ' 
Me.btnJoin.Location = New System.Drawing.Point(5, 93)
            Me.btnJoin.Name = "btnJoin"
            Me.btnJoin.Size = New System.Drawing.Size(122, 23)
            Me.btnJoin.TabIndex = 4
            Me.btnJoin.Text = "Group &Join"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnJoin.Click += new System.EventHandler(this.btnJoin_Click)
'''  ' 
            ' btnAggregates
            ' 
Me.btnAggregates.Location = New System.Drawing.Point(5, 122)
            Me.btnAggregates.Name = "btnAggregates"
            Me.btnAggregates.Size = New System.Drawing.Size(122, 23)
            Me.btnAggregates.TabIndex = 3
            Me.btnAggregates.Text = "&Aggregates"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.btnAggregates.Click += new System.EventHandler(this.btnAggregates_Click)
'''  ' 
            ' Form1
            ' 
Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(857, 487)
            Me.Controls.Add(Me.textBox1)
            Me.Controls.Add(Me.panelControl1)
            Me.Name = "Form1"
            Me.Text = "LINQ to XPO (C#)"
             ''' Cannot convert AssignmentExpressionSyntax, System.NullReferenceException: Object reference not set to an instance of an object.
'''    at ICSharpCode.CodeConverter.VB.NodesVisitor.VisitAssignmentExpression(AssignmentExpressionSyntax node)
'''    at Microsoft.CodeAnalysis.CSharp.CSharpSyntaxVisitor`1.Visit(SyntaxNode node)
'''    at ICSharpCode.CodeConverter.VB.CommentConvertingVisitorWrapper`1.Accept(SyntaxNode csNode, Boolean addSourceMapping)
''' 
''' Input:
'''             this.Load += new System.EventHandler(this.Form1_Load)
'''  CType((Me.panelControl1), System.ComponentModel.ISupportInitialize).EndInit()
            Me.panelControl1.ResumeLayout(False)
            Me.ResumeLayout(False)
            Me.PerformLayout()
        End Sub

#End Region
        Private textBox1 As System.Windows.Forms.TextBox

        Private btnSelectWhere As DevExpress.XtraEditors.SimpleButton

        Private simpleButton2 As DevExpress.XtraEditors.SimpleButton

        Private panelControl1 As DevExpress.XtraEditors.PanelControl

        Private btnAggregates As DevExpress.XtraEditors.SimpleButton

        Private btnJoin As DevExpress.XtraEditors.SimpleButton

        Private btnSelectTop As DevExpress.XtraEditors.SimpleButton

        Private btnGroup As DevExpress.XtraEditors.SimpleButton

        Private btnAny As DevExpress.XtraEditors.SimpleButton
    End Class
End Namespace
