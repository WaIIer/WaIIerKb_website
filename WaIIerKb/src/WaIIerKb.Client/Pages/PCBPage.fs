module WaIIerKb.Client.Pages.PCBPage

open System
open System.IO
open System.Collections.Generic
open Bolero
open Bolero.Html

open WaIIerKb.Client.Views.ImageGallery
open WaIIerKb.Client.Models.ModalImage
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Router.Router

let pcbImage (jpgName: string) =
    Path.Combine("images", "pcb", String.Format("{0}.jpg", jpgName))

let modalImage jpgName caption altText dispatch =
    let modal =
        { Source = pcbImage(jpgName).ToString()
          Alt = altText
          Caption = caption
          Expanded = false
          Style = "" }

    img [ attr.src modal.Source
          attr.alt altText
          attr.style "max-width: 500px; max-height: 300px"
          on.click (fun _ ->
              printfn "The image was pressed"
              ExpandImage modal |> dispatch) ]


// Redirects to other PCB Pages`s
let landingPageLinkGroup id imageSrc caption =
    div [ attr.id "row" ] [
        figure [ attr.``class`` "figure pcb-landing-figure" ] [
            img [ attr.src imageSrc
                  attr.``class`` "img-fluid"
                  attr.alt caption
                  attr.style "height: 200px; max-width: 500px" ]
            a [ router.HRef(PCB id) ] [
                figcaption [ attr.``class`` "figure-caption" ] [
                    text caption
                ]
            ]
        ]
    ]

let pcbLandingPage model dispatch =
    div [] [
        landingPageLinkGroup 1 (pcbImage "model1_front") "WaIIer47 Prototype"
        landingPageLinkGroup 2 (pcbImage "model2_front") "WaIIer47 Model 2"
        landingPageLinkGroup 3 (pcbImage "rgb_front_jlc") "WaIIer47 RGB"
    ]

let image (jpgName: string) (caption: string) (altText: string) =
    let divId = jpgName.Replace(" ", "-") + "-modal"

    div [] [
        div [ attr.``class`` "row" ] [
            button [ "data-toggle" => "modal"
                     "data-target" => "#" + divId ] [
                img [ attr.src (pcbImage jpgName)
                      attr.alt altText
                      attr.style "height: 300px; width: 500px" ]
            ]
        ]
        div [ attr.``class`` "modal fade bg-primary .opacity-3"
              attr.id divId
              attr.tabindex "-1"
              "role" => "dialog"
              "aria-labelleby" => "popupPCBImage"
              "aria-hidden" => "true" ] [
            div [ attr.``class`` "modal-dialog modal-lg" ] [
                div [ attr.``class`` "modal-header text-white" ] [
                    text caption
                ]
                div [ attr.``class`` "modal-body bg-secondary" ] [
                    img [ attr.src (pcbImage jpgName) ]
                ]
                div [ attr.``class`` "modal-footer" ] [
                    button [ attr.``type`` "button"
                             attr.``class`` "btn btn-secondary text-black"
                             "data-dismiss" => "modal" ] [
                        text "Close"
                    ]
                ]
            ]
        ]
    ]

let prototypePage model dispatch =
    div [] [
        h1 [] [ text "WaIIer47 Prototype" ]
        p [] [
            text "This was the first PCB I designed when I started
                   creating my own mechanical keyboard PCBs. There are a few mistakes in this design
                   that make it infeasible: 1) The clock signal is routed to the wrong pins. It is possble to
                   correct this by using a non-surface-mount, 2 pin crystal and mounting it to the correct pads.
                   2) The USB-C port requires resistors on the CC lines when being used in USB 2.0 mode. I did not include
                   these resistors, so this design is unable to connect to the PCB. It is also possible to rework this issue
                   by soldering the resistors directly to the Type-C receptacle. With both of these issues. I figured it was
                   easier to start a new design (WaIIer47 Model 2)"
        ]
        image "model1_front" "Front of the prototype PCB" "Prototype PCB front"
        image "model1_back" "Back of the prototype PCB" "Prototype PCB back"
    ]


let model2Page model dispatch =
    let images =
        [ { Source = pcbImage "model2_front"
            Caption = "Front of the Model 2 PCB"
            AltText = "Model 2 PCB front" }
          { Source = pcbImage "model2_back"
            Caption = "Back of the Model 2 PCB"
            AltText = "Back of the Model 2 PCB" }
          { Source = pcbImage "model2_3d_back"
            Caption = "3D render of the back of the Model 2 PCB"
            AltText = "3D render of the back of the Model 2 PCB" }
          { Source = pcbImage "model2_3d_front"
            Caption = "3D render of the front of the Model 2 PCB"
            AltText = "3D render of the front of the Model 2 PCB" } ]

    div [ attr.style "max-width: 120ch;" ] [
        div [ attr.``class`` "row" ] [
            h1 [] [ text "WaIIer47 Model 2" ]
        ]
        div [ attr.``class`` "row" ] [
            p [] [
                text "This is the second keyboard design I sent to be manufactured and it was the first one to work!
                   This designe is an improvemtn over the prototype in nearly every aspect: The PCB is shorter;
                   the dead area abover the last row of keys is reduced. The routing of the PCB is much cleaner.
                   Most importantly, it works without any reworks! After loading QMK Firmware, it works like you
                   would expect a keyboard to work (as long as you are willing to learn a lot of macros). There is
                   room for improvement -- which will be shown in the WAIIer47 RGB. I build mine using Kalih Speed Copper
                   keyswitches, which are not meant to be mounted straight into a PCB which is why some of the keys are not straight."
            ]
        ]
        imageGallery images
    ]


let pcbPage id model dispatch =
    match id with
    | _ when id <= 0 -> pcbLandingPage model dispatch
    | _ when id = 1 -> prototypePage model dispatch
    | _ when id = 2 -> model2Page model dispatch
    | _ -> pcbLandingPage model dispatch
