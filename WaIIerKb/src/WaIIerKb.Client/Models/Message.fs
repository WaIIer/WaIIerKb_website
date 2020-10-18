module WaIIerKb.Client.Models.Message

open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Models.ModalImage

type Message =
    | Ping
    | SetPage of Page
    | ExpandImage of ModalImage
