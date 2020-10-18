module WaIIerKb.Client.Models.Message

open WaIIerKb.Client.Models.Model

type Message =
    | Ping
    | SetPage of Page
