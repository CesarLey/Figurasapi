using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using Swashbuckle.AspNetCore.Annotations;

namespace FigurasApi.Models
{
    [SwaggerSchema(Description = "Modelo para una figura geométrica. Solo llena los campos de dimensiones que correspondan al tipo de figura.")]
    public class Figura
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [SwaggerSchema(Description = "Tipo de figura: cubo, esfera, piramide, cilindro, rectangulo, circulo, cuboide, cono", Nullable = false)]
        public string TipoFigura { get; set; } = string.Empty;

        [SwaggerSchema(Description = "Arista del cubo", Nullable = true)]
        public double? Arista { get; set; } // Para Cubo

        [SwaggerSchema(Description = "Radio de la esfera, cilindro, círculo o cono", Nullable = true)]
        public double? Radio { get; set; } // Para Esfera, Cilindro, Círculo, Cono

        [SwaggerSchema(Description = "Altura de la pirámide, cilindro o cono", Nullable = true)]
        public double? Altura { get; set; } // Para Pirámide, Cilindro, Cono

        [SwaggerSchema(Description = "Base de la pirámide o rectángulo", Nullable = true)]
        public double? Base { get; set; } // Para Pirámide, Rectángulo

        [SwaggerSchema(Description = "Largo del cuboide", Nullable = true)]
        public double? Largo { get; set; } // Para Cuboide

        [SwaggerSchema(Description = "Ancho del cuboide", Nullable = true)]
        public double? Ancho { get; set; } // Para Cuboide

        [DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        [SwaggerSchema(ReadOnly = true, Description = "Volumen o área calculado automáticamente", Nullable = false)]
        public double Volumen { get; set; }

        public void CalcularVolumen()
        {
            switch (TipoFigura.ToLower())
            {
                case "cubo":
                    if (Arista.HasValue)
                        Volumen = Math.Pow(Arista.Value, 3);
                    break;
                case "esfera":
                    if (Radio.HasValue)
                        Volumen = (4.0 / 3.0) * Math.PI * Math.Pow(Radio.Value, 3);
                    break;
                case "piramide":
                    if (Base.HasValue && Altura.HasValue)
                        Volumen = (Base.Value * Altura.Value) / 3.0;
                    break;
                case "cilindro":
                    if (Radio.HasValue && Altura.HasValue)
                        Volumen = Math.PI * Math.Pow(Radio.Value, 2) * Altura.Value;
                    break;
                case "rectangulo":
                    if (Base.HasValue && Altura.HasValue)
                        Volumen = Base.Value * Altura.Value;
                    break;
                case "circulo":
                    if (Radio.HasValue)
                        Volumen = Math.PI * Math.Pow(Radio.Value, 2);
                    break;
                case "cuboide":
                    if (Largo.HasValue && Ancho.HasValue && Altura.HasValue)
                        Volumen = Largo.Value * Ancho.Value * Altura.Value;
                    break;
                case "cono":
                    if (Radio.HasValue && Altura.HasValue)
                        Volumen = (1.0 / 3.0) * Math.PI * Math.Pow(Radio.Value, 2) * Altura.Value;
                    break;
                default:
                    Volumen = 0;
                    break;
            }
        }
    }
} 