module WaIIerKb.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Remoting.Client
open Bolero.Templating.Client


open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Models.ModalImage
open WaIIerKb.Client.Router.Router
open WaIIerKb.Client.Pages.HomePage
open WaIIerKb.Client.Pages.AboutPage
open WaIIerKb.Client.Pages.TutorialLandingPage
open WaIIerKb.Client.Pages.PCBPage
open WaIIerKb.Client.Pages.CablePage

let initModel =
    { Page = Home
      Modal = blankModalImage
      Tutorial = emptyTutorialModel }

let toggleStep step model =
    printfn "%d" step.Id
    printfn "%d" (model.Tutorial.Steps.[0].Id)
    { model with
          Tutorial =
              { model.Tutorial with
                    Steps =
                        model.Tutorial.Steps
                        |> List.map (fun _step ->
                            if (step.Id = _step.Id) then
                                printfn "found the step"
                                { _step with
                                      IsComplete = (not _step.IsComplete) }
                            else
                                printfn "did not find it"
                                _step) } }


let update (message: Message) model =
    printfn "%s" (message.GetType().ToString())
    match message with
    | Ping -> model
    | SetPage page -> { model with Page = page }
    | ExpandImage modalImage ->
        { model with
              Modal = { modalImage with Expanded = true } }
    | ToggleTutorialStep step -> toggleStep step model
    | SetTutorial tutorial -> { model with Tutorial = tutorial }
    | CloseImage -> { model with Modal = blankModalImage }

let view model dispatch =
    match model.Page with
    | Home -> homePage model dispatch
    | About -> aboutPage model dispatch
    | Tutorials -> tutorialLandingPage model dispatch
    | Tutorial id -> tutorialPage id model dispatch
    | PCB id -> pcbPage id model dispatch
    | Cable -> cablePage model dispatch
    | _ -> homePage model dispatch



type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
        |> Program.withRouter router
#if DEBUG
        |> Program.withHotReload
#endif
