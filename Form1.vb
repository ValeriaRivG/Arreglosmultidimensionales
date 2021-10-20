Public Class Form1
    'Declaración de variables
    Private mPlatos(,) As String
    Private cantPlatos As String
    Private index As Integer
    Private encuentra As Integer = 0

    Private Sub Form1_Load(sender As System.Object, e As System.EventArgs) Handles MyBase.Load
        btnVender.Enabled = False
        txtPrecio.Enabled = False
        txtDisponible.Enabled = False
    End Sub

    Private Sub btnCargar_Click(sender As System.Object, e As System.EventArgs) Handles btnCargar.Click
        'Entrada de datos
        cantPlatos = Val(txtCantPlatos.Text)
        'Inicializar ahora la matriz
        ReDim Preserve mPlatos(cantPlatos, 3)
        'Ingresar datos a nuestra matriz
        For i As Integer = 0 To cantPlatos - 1 Step 1
            mPlatos(i, 0) = InputBox("Ingresa el nombre del plato " & (i + 1), "Restaurant")
            mPlatos(i, 1) = InputBox("Ingresa el precio del plato " & (i + 1), "Restaurant")
            mPlatos(i, 2) = InputBox("Ingresa el stock del plato " & (i + 1), "Restaurant")
        Next
    End Sub

    Private Sub btnBuscar_Click(sender As System.Object, e As System.EventArgs) Handles btnBuscar.Click
        Dim Plato As String
        Plato = txtPlato.Text
        For i As Integer = 0 To (cantPlatos - 1) Step 1
            If (mPlatos(i, 0) = Plato) Then
                txtPrecio.Text = mPlatos(i, 1)
                txtDisponible.Text = mPlatos(i, 2)
                index = i
                btnVender.Enabled = True
                encuentra = 1
            End If
        Next
        If (encuentra = 0) Then
            MessageBox.Show("No existe el plato", "Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Error)
            btnVender.Enabled = False
        End If
    End Sub

    Private Sub btnVender_Click(sender As System.Object, e As System.EventArgs) Handles btnVender.Click
        Dim cant As Integer, stock As Integer
        cant = Val(txtCantidad.Text)
        stock = mPlatos(index, 2)
        If (cant <= stock) Then
            'Disminuir el stock del plato
            mPlatos(index, 2) = stock - cant
        Else
            MessageBox.Show("No hay suficiente stock", "Restaurant", MessageBoxButtons.OK, MessageBoxIcon.Information)
        End If
    End Sub

    Private Sub btnSalir_Click(sender As System.Object, e As System.EventArgs) Handles btnSalir.Click
        Close()
    End Sub
End Class
