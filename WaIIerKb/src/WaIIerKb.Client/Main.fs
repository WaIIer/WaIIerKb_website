module WaIIerKb.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Remoting.Client
open Bolero.Templating.Client


open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Router.Router
open WaIIerKb.Client.Pages.HomePage
open WaIIerKb.Client.Pages.AboutPage

let initModel = { x = ""; Page = Home }

let update message model =
    match message with
    | Ping -> model
    | SetPage page -> { model with Page = page }

let view model dispatch =
    match model.Page with
    | Home -> homePage model dispatch
    | About -> aboutPage model dispatch
    | _ -> homePage model dispatch



type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
        |> Program.withRouter router
#if DEBUG
        |> Program.withHotReload
#endif
