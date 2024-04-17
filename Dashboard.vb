Imports System.Data.SqlClient
Public Class Dashboard
    Dim con As New SqlConnection("Data Source=(LocalDB)\v11.0;AttachDbFilename=E:\Visual Baisc\DentalClinic\DentalClinic\DentalClinic.mdf;Integrated Security=True")
    Dim cmd As SqlCommand
    Private Sub Label3_Click(sender As Object, e As EventArgs) Handles Label3.Click

    End Sub

    Private Sub PreTreat_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Label7_Click(sender As Object, e As EventArgs)
    End Sub

    Private Sub PreCost_TextChanged(sender As Object, e As EventArgs)
    End Sub

    Private Sub Panel2_Paint(sender As Object, e As PaintEventArgs) Handles Panel2.Paint

    End Sub
    Private Sub CountPatient()
        con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("Select count(*) from Patient", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As DataTable
        dt = New DataTable()
        adapter.Fill(dt)
        PatientNum.Text = dt.Rows(0)(0).ToString


        con.Close()
    End Sub
    Private Sub CountTreatment()
        con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("Select count(*) from Treatment", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As DataTable
        dt = New DataTable()
        adapter.Fill(dt)
        TreatmentNum.Text = dt.Rows(0)(0).ToString


        con.Close()
    End Sub
    Private Sub CountPrescription()
        con.Open()
        Dim cmd As SqlCommand
        cmd = New SqlCommand("Select count(*) from Prescription", con)
        Dim adapter As New SqlDataAdapter(cmd)
        Dim dt As DataTable
        dt = New DataTable()
        adapter.Fill(dt)
        PrescriptionNum.Text = dt.Rows(0)(0).ToString


        con.Close()
    End Sub
    Private Sub Dashboard_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        CountPrescription()
        CountTreatment()
        CountPatient()
    End Sub

    Private Sub Label9_Click(sender As Object, e As EventArgs) Handles DashPrescription.Click

    End Sub

    Private Sub Label5_Click(sender As Object, e As EventArgs) Handles PatientNum.Click

    End Sub

    Private Sub Label8_Click(sender As Object, e As EventArgs) Handles PrescriptionNum.Click

    End Sub

    Private Sub Label15_Click(sender As Object, e As EventArgs) Handles Label15.Click
        Me.Hide()
        Dim Obj = New Login
        Obj.Show()

    End Sub

    Private Sub Label14_Click(sender As Object, e As EventArgs) Handles Label14.Click
        Me.Hide()
        Dim Obj = New Patient
        Obj.Show()

    End Sub

    Private Sub Label13_Click(sender As Object, e As EventArgs) Handles Label13.Click
        Me.Hide()
        Dim Obj = New Prescription
        Obj.Show()

    End Sub

    Private Sub Label12_Click(sender As Object, e As EventArgs) Handles Label12.Click
        Me.Hide()
        Dim Obj = New Treatment
        Obj.Show()

    End Sub

    Private Sub Label11_Click(sender As Object, e As EventArgs) Handles Label11.Click
        Me.Hide()
        Dim Obj = New Appoinment
        Obj.Show()

    End Sub

    Private Sub TreatmentNum_Click(sender As Object, e As EventArgs) Handles TreatmentNum.Click

    End Sub
End Class