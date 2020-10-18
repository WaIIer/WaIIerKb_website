module WaIIerKb.Client.Router.Router

open Bolero

open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Models.Model

let router =
    Router.infer SetPage (fun model -> model.Page)
