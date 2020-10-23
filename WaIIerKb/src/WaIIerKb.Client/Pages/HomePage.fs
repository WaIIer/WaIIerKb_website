module WaIIerKb.Client.Pages.HomePage

open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Router.Router


open Bolero
open Bolero.Html

let homePage model dispatch =
    let navbarA active page liText =
        a [ attr.``class``
                ("nav-item nav-link text-white"
                 + if active then " active" else "")
            router.HRef page ] [
            text liText
        ]

    div [] [
        div [ attr.``class`` "jumbotron jumbotron-fluid" ] [
            div [ attr.``class`` "container" ] [
                h1 [ attr.``class`` "display-4" ] [
                    text "WaIIer Keyboards"
                ]
                p [ attr.``class`` "lead" ] [
                    text "Open source ortholinear mechanical keyboards"
                ]
            ]
        ]
        nav [ attr.``class`` "navbar navbar-expand-lg navbar-light bg-primary" ] [
            div [ attr.``class`` "collapse navbar-collapse"
                  attr.id "navbarNavAltMarkup" ] [
                div [ attr.``class`` "navbar-nav" ] [
                    navbarA true Home "Home"
                    navbarA false About "About"
                    navbarA false Cable "Cables"
                    navbarA false Keyboards "Keyboards"
                    navbarA false Cases "Cases"
                    navbarA false Tutorial "Tutorial"
                    navbarA false InterestCheck "Interest Check"
                ]
            ]
        ]
    ]
