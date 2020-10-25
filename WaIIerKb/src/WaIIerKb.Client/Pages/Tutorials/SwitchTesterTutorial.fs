module WaIIerKb.Client.Pages.Tutorials.SwitchTesterTutorial

open Bolero.Html

open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Lib.Units
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Pages.Tutorials.TutorialLib

let switchTesterTutorial =
    { Name = "Switch Tester Tutorial"
      Steps =
          [ { Id = 1
              Name = "Prepare Your Workspace"
              YoutubeLink = "https://www.youtube.com/embed/isey-2RrA1o"
              TimeEstimate = 10<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      text "Prepare your workspace with the following things"
                  ] } ] }

let switchTesterTutorialPage model dispatch = generateTutorialHtml model dispatch
