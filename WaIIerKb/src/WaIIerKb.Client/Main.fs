module WaIIerKb.Client.Main

open Elmish
open Bolero
open Bolero.Html
open Bolero.Templating.Client

type Model = { x: string }

let initModel = { x = "" }

type Message = | Ping

let update message model =
    match message with
    | Ping -> model

let navbarLi active href liText =
    li [ attr.``class`` ("nav-item" + if active then " active" else "") ] [
        a [ attr.``class`` "nav-link text-white"
            attr.href href ] [
            text liText
        ]
    ]

let view model dispatch =
    div [] [
        div [ attr.``class`` "jumbotron jumbotron-fluid" ] [
            div [ attr.``class`` "container" ] [
                h1 [ attr.``class`` "display-4" ] [
                    text "WaIIer Keyboards"
                ]
                p [ attr.``class`` "lead" ] [
                    text "Open source ortholinear mechanical keyboards"
                ]
                nav [ attr.``class`` "navbar navbar-expand-lg bg-primary text-white" ] [
                    a [ attr.``class`` "collapse navbar-collapse"
                        attr.id "navbarSupportedContent" ] [
                        ul [ attr.``class`` "navbar-nav mr-auto" ] [
                            navbarLi true "#" "Home"
                            navbarLi false "#" "About"
                            navbarLi false "#" "Keyboards"
                            navbarLi false "#" "Cases"
                            navbarLi false "#" "Tutorial"
                            navbarLi false "#" "Interest Check"
                        ]
                    ]
                ]
            ]
        ]
    ]


type MyApp() =
    inherit ProgramComponent<Model, Message>()

    override this.Program =
        Program.mkSimple (fun _ -> initModel) update view
#if DEBUG
        |> Program.withHotReload
#endif
