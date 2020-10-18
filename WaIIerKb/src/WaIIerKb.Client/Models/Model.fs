module WaIIerKb.Client.Models.Model

open Bolero

type Page =
    | [<EndPoint "/">] Home
    | [<EndPoint "/about">] About
    | [<EndPoint "/keyboards">] Keyboards
    | [<EndPoint "/cases">] Cases
    | [<EndPoint "/tutorial">] Tutorial
    | [<EndPoint "/interest-check">] InterestCheck

type Model = { x: string; Page: Page }
