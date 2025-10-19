namespace TareaSemana1GQuishpe.Views;

public partial class Inicio : ContentPage
{
	public Inicio()
	{
		InitializeComponent();
	}

    private void btnCalcular_Clicked(object sender, EventArgs e)
    {
        try
        {
            string nombre = txtNombre.Text;
            string apellido = txtApellido.Text;
            int edad = int.Parse(txtEdad.Text);
            decimal salario = decimal.Parse(txtSalario.Text);

            decimal aporte = salario * 0.0945m;

            string mensaje = $"Bienvenido {nombre} {apellido}\n" +
                             $"Tienes {edad} años\n" +
                             $"Tu aporte mensual es ${aporte:F2}";

            DisplayAlert("Resultado", mensaje, "Cerrar");
        }
        catch (Exception)
        {
            DisplayAlert("Error", "Por favor ingresa correctamente todos los datos.", "Ok");
        }
    }
    private void txtEdad_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtEdad.Text))
        {
            string texto = txtEdad.Text;
            string filtrado = new string(texto.Where(char.IsDigit).ToArray());

            if (texto != filtrado)
            {
                DisplayAlert("Error", "Solo se permiten números.", "Ok");
                txtEdad.Text = filtrado;
                txtEdad.CursorPosition = filtrado.Length;
            }
        }
    }

    private void txtSalario_TextChanged(object sender, TextChangedEventArgs e)
    {
        if (!string.IsNullOrEmpty(txtSalario.Text))
        {
            string texto = txtSalario.Text;
            bool puntoEncontrado = false;

            string filtrado = new string(texto.Where(c =>
            {
                if (char.IsDigit(c)) return true;
                if (c == '.' && !puntoEncontrado)
                {
                    puntoEncontrado = true;
                    return true;
                }
                return false;
            }).ToArray());

            // Si el texto original no es igual al filtrado, es porque había letras
            if (texto != filtrado)
            {
                DisplayAlert("Error", "Solo se permiten números.", "Ok");
                txtSalario.Text = filtrado;
                txtSalario.CursorPosition = filtrado.Length;
            }
        }
    }





}