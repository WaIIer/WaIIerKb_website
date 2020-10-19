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
open WaIIerKb.Client.Pages.PCBPage

let initModel = { Page = Home; Modal = blankModalImage }

let update (message: Message) model =
    printfn "%s" (message.GetType().ToString())
    match message with
    | Ping -> model
    | SetPage page -> { model with Page = page }
    | ExpandImage modalImage ->
        { model with
              Modal = { modalImage with Expanded = true } }
    | CloseImage -> { model with Modal = blankModalImage }

let view model dispatch =
    match model.Page with
    | Home -> homePage model dispatch
    | About -> aboutPage model dispatch
    | PCB id -> pcbPage id model dispatch
    | _ -> homePage model dispatch



type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
        |> Program.withRouter router
#if DEBUG
        |> Program.withHotReload
#endif
