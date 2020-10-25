module WaIIerKb.Client.Pages.TutorialLandingPage

open System.IO
open Bolero
open Bolero.Html

open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Router.Router
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Lib.Units
open WaIIerKb.Client.Pages.Tutorials.SwitchTesterTutorial


let private _thumbnailMaxWidth = 75<px>

let TutorialId = {| SwitchTester = 0 |}

let tutorialOptionRow image name (id: int) dispatch =
    let href = router.HRef(Tutorial id)
    a [ href
        attr.``class`` "row"
        attr.style "margin-top: 10px;"
        on.click (fun _ -> (SetTutorial switchTesterTutorial |> dispatch)) ] [
        div [ attr.``class`` "col-sm" ] [
            img [ attr.src image
                  attr.``class`` "thumbnail"
                  attr.style (sprintf "max-width: %dpx; max-height: %dpx;" _thumbnailMaxWidth _thumbnailMaxWidth) ]
        ]
        div [ attr.``class`` "col-sm" ] [
            h1 [] [ text name ]
        ]
        div [ attr.``class`` "col-sm" ] [
            button [ attr.``type`` "button"
                     attr.``class`` "btn btn-primary"
                     on.click (fun _ -> (SetTutorial switchTesterTutorial |> dispatch)) ] [
                text "Go"
            ]
        ]
    ]

let tutorialLandingPage model dispatch =
    div [] [
        div [ attr.``class`` "row bg-primary text-white" ] [
            div [ attr.``class`` "col" ] [
                h1 [] [ text "Tutorials" ]
            ]
        ]
        tutorialOptionRow
            (Path.Combine("images", "pcb", "switch_tester.jpg"))
            "Switch Tester"
            TutorialId.SwitchTester
            dispatch
    ]

/// Router for other tutorial pages
let tutorialPage id model dispatch =
    match id with
    | _ when id = TutorialId.SwitchTester -> switchTesterTutorialPage model dispatch
    | _ -> h1 [] [ text "Invalid Id" ]
