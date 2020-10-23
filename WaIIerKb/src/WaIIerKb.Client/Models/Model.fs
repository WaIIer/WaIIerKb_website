module WaIIerKb.Client.Models.Model


open WaIIerKb.Client.Models.ModalImage

open Bolero

type Page =
    | [<EndPoint "/">] Home
    | [<EndPoint "/about">] About
    | [<EndPoint "/pcb/{id}">] PCB of id: int
    | [<EndPoint "/keyboards">] Keyboards
    | [<EndPoint "/cables">] Cable
    | [<EndPoint "/cases">] Cases
    | [<EndPoint "/tutorial">] Tutorial
    | [<EndPoint "/interest-check">] InterestCheck

type Model = { Page: Page; Modal: ModalImage }
