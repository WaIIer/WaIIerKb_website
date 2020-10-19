module WaIIerKb.Client.Models.ModalImage

open Bolero.Html

type ModalImage =
    { Source: string
      Alt: string
      Caption: string
      Expanded: bool
      Style: string }

let blankModalImage =
    { Source = ""
      Alt = ""
      Caption = ""
      Expanded = false
      Style = "" }

let closeSpan onClick =
    span [ attr.``class`` "glyphicon glyphicon-remove close"
           on.click onClick ] [
        text ""
    ]
