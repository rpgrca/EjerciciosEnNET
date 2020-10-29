Public Class Constantes

    Public Const CLIENTE_JUAN_PEREZ As String = "Juan Perez"
    Public Const TELEFONO_DE_JUAN_PEREZ As String = "4444-4444"
    Public Const CORREO_DE_JUAN_PEREZ As String = "juan.perez@hotmail.com"

    Public Const CLIENTE_EDUARDO_PEREZ As String = "Eduardo Perez"
    Public Const TELEFONO_DE_EDUARDO_PEREZ As String = "5555-5555"
    Public Const CORREO_DE_EDUARDO_PEREZ As String = "eduardo.perez@yahoo.com"

    Public Const CLIENTE_MARTINA_PEREZ As String = "Martina Perez"

    Public Const LATA_DE_ARVEJAS As String = "Lata de arvejas Arcor"
    Public Const PRECIO_UNITARIO_LATA_DE_ARVEJAS As Decimal = 45
    Public Const CODIGO_DE_LATA_DE_ARVEJAS As String = "LATARJ1"
    Public Const CANTIDAD_COMPRA_LATAS_DE_ARVEJAS As Integer = 6
    Public Const TOTAL_LATAS_DE_ARVEJAS As Decimal = PRECIO_UNITARIO_LATA_DE_ARVEJAS * CANTIDAD_COMPRA_LATAS_DE_ARVEJAS

    Public Const LATA_DE_CERVEZA As String = "Lata de cerveza Quilmes"
    Public Const PRECIO_UNITARIO_LATA_DE_CERVEZA As Decimal = 75
    Public Const CODIGO_DE_LATA_DE_CERVEZA As String = "QUI11"
    Public Const CANTIDAD_COMPRA_LATAS_DE_CERVEZA As Integer = 2
    Public Const TOTAL_LATAS_DE_CERVEZA As Decimal = PRECIO_UNITARIO_LATA_DE_CERVEZA * CANTIDAD_COMPRA_LATAS_DE_CERVEZA

    Public Const TOTAL_CANTIDAD_LATAS_DE_ARVEJAS_Y_CERVEZA As Integer = CANTIDAD_COMPRA_LATAS_DE_CERVEZA + CANTIDAD_COMPRA_LATAS_DE_CERVEZA
    Public Const TOTAL_LATAS_DE_ARVEJAS_Y_CERVEZA As Decimal = TOTAL_LATAS_DE_ARVEJAS + TOTAL_LATAS_DE_CERVEZA

    Public Const FECHA_PRIMER_COMPRA As Date = #2020/12/13#
    Public Const FECHA_SEGUNDA_COMPRA As Date = #2020/12/14#
End Class