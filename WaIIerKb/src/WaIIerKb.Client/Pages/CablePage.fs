module WaIIerKb.Client.Pages.CablePage

open Bolero.Html
open System.IO

open WaIIerKb.Client.Views.ImageGallery

let cableImage jpgName =
    Path.Combine("images", "cables", (sprintf "%s.jpg" jpgName))

let cablePage model disptach =
    div [ attr.style "max-width: 120ch;" ] [
        div [ attr.``class`` "row" ] [
            h1 [] [ text "Custom Cables" ]
        ]
        div [ attr.``class`` "row" ] [
            p [] [
                text "This was my first attempt at a custom double sleeved USB cable.
                       It did not go very well..

                       This was a Monoprice USB 2.0 cable. Both ends were removed. The cable
                       was then sleeved with paracord then Techflex. The two USB connectors were
                       soldered to each end. Finally heat shrink was used over the connectors to
                       hide the exposed wire."
            ]
        ]
        imageGallery [ { Source = cableImage "cable_1"
                         Caption = "My first attempt at a custom cable"
                         AltText = "My first attempt at a custom sleeved cable" } ]
    ]
