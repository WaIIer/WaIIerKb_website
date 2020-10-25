module WaIIerKb.Client.Pages.Tutorials.TutorialLib

open Bolero.Html

open WaIIerKb.Client.Lib.Units
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Models.Message

let private youtubeWidth = 160<px>
let private youtubeHeight = 90<px>

let private youtubeStyle =
    sprintf "max-height: %dpx; max-width: %dpx" youtubeHeight youtubeWidth


let private stepInnerHtml step dispatch =
    [
      // video
      div [ attr.``class`` "col" ] [
          iframe [ attr.``class`` "embed-responsive-16by9"
                   attr.src step.YoutubeLink
                   attr.allow "fullscreen" ] []
      ]
      // step text
      div [ attr.``class`` "col" ] [
          step.HtmlText
      ]
      // mark as complete button
      div [ attr.``class`` "col" ] [
          button [ attr.``type`` "button"
                   attr.``class`` (if (step.IsComplete) then "btn btn-secondary" else "btn btn-primary")
                   on.click (fun _ -> (ToggleTutorialStep step |> dispatch)) ] [
              text (if (step.IsComplete) then "Mark Incomplete" else "Mark Complete")
          ]
      ] ]

let private tutorialStep accordionId stepId (step: Step) model dispatch =
    let bg =
        if step.IsComplete then "bg-success" else "bg-primary"

    let cardId = sprintf "tutorial-step-%d" stepId
    let headingId = "heading-" + cardId
    div [ attr.``class`` "card"
          attr.style "margin-top: 10px" ] [
        div [ attr.``class`` ("card-header text-white " + bg)
              attr.id headingId ] [
            h2 [ attr.``class`` "mb-0" ] [
                button [ attr.``class`` "btn btn-link"
                         attr.``type`` "button"
                         "data-toggle" => "collapse"
                         "data-target" => "#" + cardId
                         "aria-expanded" => "false"
                         "aria-controls" => cardId ] [
                    h3 [ attr.``class`` "float-right text-white align-top" ] [
                        text (sprintf "%d. %s| %d minutes" step.Id step.Name step.TimeEstimate)
                    ]
                ]
            ]
        ]
        div [ attr.id cardId
              attr.``class`` "collapse"
              attr.style "margin-top: 20px"
              "aria_labelleby" => headingId
              "data-parent" => "#" + accordionId ] [
            div [ attr.``class`` "row" ] (stepInnerHtml step dispatch)
        ]
    ]


let generateTutorialHtml model dispatch =
    let steps = model.Tutorial.Steps.Length

    let complete =
        model.Tutorial.Steps
        |> List.filter (fun step -> step.IsComplete)

    div [] [
        div [ attr.id "tutorial-heading"
              attr.``class``
                  ("card text-white "
                   + if complete.Length = steps then "bg-success" else "bg-primary")
              attr.style "margin: 20px" ] [
            div [ attr.``class`` "card-header" ] [
                text model.Tutorial.Name
            ]
            div [ attr.``class`` "card-body" ] [
                text
                    (sprintf
                        "%d/%d Steps Complete"
                         (model.Tutorial.Steps
                          |> List.filter (fun step -> step.IsComplete)
                          |> List.length)
                         model.Tutorial.Steps.Length)
                text
                    (sprintf
                        "About %d Minutes Left"
                         (model.Tutorial.Steps
                          |> List.sumBy (fun step -> if not step.IsComplete then step.TimeEstimate else 0<minute>)))
            ]
        ]
        div
            [ attr.id (model.Tutorial.Name.Replace(" ", "-"))
              attr.``class`` "accordion" ]
            (model.Tutorial.Steps
             |> List.mapi (fun index step ->
                 tutorialStep (model.Tutorial.Name.Replace(" ", "-")) (index + 1) step model dispatch))
    ]
