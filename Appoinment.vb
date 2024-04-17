Imports System.Data.SqlClient
Public Class Appoinment
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Visual Baisc\DentalClinic\DentalClinic\DentalClinic.mdf;Integrated Security=True")
    Dim cmd As SqlCommand
    Private Sub fillPatient()
        con.Open()
        Dim sql = "select * from Patient"

        Dim cmd As New SqlCommand(sql, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        AppPatient.DataSource = Tbl
        AppPatient.DisplayMember = "PatName"
        AppPatient.ValueMember = "PatName"
        con.Close()
    End Sub
    Private Sub fillTreatment()
        con.Open()
        Dim sql = "select * from Treatment"

        Dim cmd As New SqlCommand(sql, con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim Tbl As New DataTable()
        adapter.Fill(Tbl)
        AppTreat.DataSource = Tbl
        AppTreat.DisplayMember = "TrName"
        AppTreat.ValueMember = "TrName"
        con.Close()





    End Sub
    Private Sub Populate()
        con.Open()
        Dim quary = "select * from Appoinment"
        Dim adapter As SqlDataAdapter
        adapter = New SqlDataAdapter(quary, con)
        Dim builder As New SqlCommandBuilder(adapter)
        Dim ds As DataSet
        ds = New DataSet
        adapter.Fill(ds)
        AppGDV.DataSource = ds.Tables(0)
        con.Close()

    End Sub
    Private Sub Filter()
        If SearchTb.Text = "" Then
            MsgBox("Enter the  Patient Name")
        Else
            con.Open()
            Dim quary = "select * from Appoinment where ApPat='" & SearchTb.Text & "'"
            Dim adapter As SqlDataAdapter
            adapter = New SqlDataAdapter(quary, con)
            Dim builder As New SqlCommandBuilder(adapter)
            Dim ds As DataSet
            ds = New DataSet
            adapter.Fill(ds)
            AppGDV.DataSource = ds.Tables(0)
            SearchTb.Text = ""
            con.Close()
        End If
    End Sub
    Private Sub Reset()
        AppPatient.SelectedIndex = -1
        AppTreat.SelectedIndex = -1
    End Sub
    Private Sub Appoinment_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        fillPatient()
        fillTreatment()
        Populate()

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Dim Obj = New Patient
        Obj.Show()

    End Sub

    Private Sub ListView1_SelectedIndexChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub PictureBox1_Click(sender As Object, e As EventArgs) Handles PictureBox1.Click

    End Sub

    Private Sub PictureBox2_Click(sender As Object, e As EventArgs) Handles PictureBox2.Click

    End Sub

    Private Sub PictureBox3_Click(sender As Object, e As EventArgs) Handles PictureBox3.Click

    End Sub

    Private Sub PictureBox4_Click(sender As Object, e As EventArgs) Handles PictureBox4.Click

    End Sub

    Private Sub PictureBox5_Click(sender As Object, e As EventArgs) Handles PictureBox5.Click

    End Sub

    Private Sub PictureBox6_Click(sender As Object, e As EventArgs) Handles PictureBox6.Click

    End Sub

    Private Sub Label16_Click(sender As Object, e As EventArgs) Handles Label16.Click

    End Sub
    Dim key = 0
    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles AppDelete.Click
        If key = 0 Then
            MsgBox("Missing Information")
        Else
            con.Open()
            Dim quary = "delete from Appoinment where ApId=" & key & ""
            Dim cmd As New SqlCommand(quary, con)
            cmd.ExecuteNonQuery()
            MsgBox("Appoinment Delete Succesfully!!")
            con.Close()
            Populate()

        End If
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles AppSave.Click
        If AppPatient.SelectedIndex = -1 Or AppTreat.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            con.Open()
            Dim quary = "insert into Appoinment values( '" + AppPatient.SelectedValue.ToString() + "','" + AppTreat.SelectedValue.ToString() + "','" + AppDate.Value.Date + "','" + AppTime.Text + "')"
            Dim cmd As New SqlCommand(quary, con)
            cmd.ExecuteNonQuery()
            MsgBox("Appoinment Save Succesfully!!")
            con.Close()
            Populate()
            Reset()


        End If
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles AppEdit.Click
        If AppPatient.SelectedIndex = -1 Or AppTreat.SelectedIndex = -1 Then
            MsgBox("Missing Information")
        Else
            con.Open()
            Dim quary = "update Appoinment set  ApPat='" & AppPatient.SelectedValue.ToString() & "',ApTreat='" & AppTreat.SelectedValue.ToString() & "',ApDate='" & CDate(AppDate.Value.Date) & "',ApTime='" & CDate(AppTime.Value.Date) & "'"
            Dim cmd As New SqlCommand(quary, con)
            cmd.ExecuteNonQuery()
            MsgBox("Appinment Update Succesfully!!")
            con.Close()
            Populate()

        End If
    End Sub

    Private Sub DateTimePicker1_ValueChanged(sender As Object, e As EventArgs) Handles AppDate.ValueChanged

    End Sub

    Private Sub ComboBox3_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppTreat.SelectedIndexChanged

    End Sub

    Private Sub ComboBox1_SelectedIndexChanged(sender As Object, e As EventArgs) Handles AppPatient.SelectedIndexChanged

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles Label5.Click

    End Sub

    Private Sub Label4_Click(sender As Object, e As EventArgs) Handles Label4.Click

    End Sub

    Private Sub Label10_Click(sender As Object, e As EventArgs) Handles Label10.Click

    End Sub

    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles Label1.Click

    End Sub

    Private Sub Label2_Click(sender As Object, e As EventArgs) Handles Label2.Click

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.Hide()
        Dim Obj = New Treatment
        Obj.Show()

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Hide()
        Dim obj = New Prescription
        obj.Show()

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Me.Hide()
        Dim Obj = New Dashboard
        Obj.Show()

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Me.Hide()
        Dim Obj = New Login
        Obj.Show()

    End Sub

    Private Sub Panel1_Paint(sender As Object, e As PaintEventArgs) Handles Panel1.Paint

    End Sub

    Private Sub AppGDV_CellContentClick(sender As Object, e As DataGridViewCellEventArgs) Handles AppGDV.CellContentClick

    End Sub

    Private Sub AppGDV_CellMouseClick(sender As Object, e As DataGridViewCellMouseEventArgs) Handles AppGDV.CellMouseClick
        Dim row As DataGridViewRow = AppGDV.Rows(e.RowIndex)
        AppPatient.Text = row.Cells(1).Value.ToString
        AppTreat.Text = row.Cells(2).Value.ToString
        AppDate.Text = row.Cells(3).Value.ToString
        AppTime.Text = row.Cells(4).Value.ToString

       
        If AppPatient.SelectedIndex = -1 Then
            key = 0
        Else
            key = Convert.ToInt32(row.Cells(0).Value.ToString)
        End If
    End Sub

    Private Sub cmdSearch_Click(sender As Object, e As EventArgs) Handles cmdSearch.Click
        Filter()
    End Sub

    Private Sub PictureBox7_Click(sender As Object, e As EventArgs) Handles PictureBox7.Click
        Populate()
    End Sub

    Private Sub SearchTb_TextChanged(sender As Object, e As EventArgs) Handles SearchTb.TextChanged

    End Sub

    Private Sub cmdPrint_Click(sender As Object, e As EventArgs) Handles cmdPrint.Click
        PrintPreviewDialog1.Show()

    End Sub

    Private Sub PrintPreviewDialog1_Load(sender As Object, e As EventArgs) Handles PrintPreviewDialog1.Load

    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        e.Graphics.DrawString("Appoinment List ", New Font("Century Gothic", 25), Brushes.MidnightBlue, 300, 40)
        e.Graphics.DrawString("*****Dental Clinc*****", New Font("Century Gothic", 16), Brushes.MidnightBlue, 320, 85)
        Dim bm As New Bitmap(Me.AppGDV.Width, Me.AppGDV.Height)
        AppGDV.DrawToBitmap(bm, New Rectangle(0, 0, AppGDV.Width, Me.AppGDV.Height))
        e.Graphics.DrawImage(bm, 2, 120)
        e.Graphics.DrawString("*******Developped By Navod Priyashan********", New Font("Century Gothic", 15), Brushes.Crimson, 48, 1100)

    End Sub

    Private Sub AppTime_ValueChanged(sender As Object, e As EventArgs)

    End Sub

    Private Sub Label6_Click(sender As Object, e As EventArgs) Handles Label6.Click

    End Sub
End Class