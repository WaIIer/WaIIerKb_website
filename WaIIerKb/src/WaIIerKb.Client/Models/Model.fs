module WaIIerKb.Client.Models.Model


open WaIIerKb.Client.Models.ModalImage
open WaIIerKb.Client.Lib.Units

open Bolero

type TutorialModel = { Steps: Step list; Name: string }

and Step =
    { YoutubeLink: string
      Name: string
      HtmlText: Node
      IsComplete: bool
      TimeEstimate: int<minute>
      Id: int }

let emptyTutorialModel = { Steps = []; Name = "" }

type Page =
    | [<EndPoint "/">] Home
    | [<EndPoint "/about">] About
    | [<EndPoint "/pcb/{id}">] PCB of id: int
    | [<EndPoint "/keyboards">] Keyboards
    | [<EndPoint "/cables">] Cable
    | [<EndPoint "/cases">] Cases
    | [<EndPoint "/tutorial">] Tutorials
    | [<EndPoint "/tutorial/{id}">] Tutorial of id: int
    | [<EndPoint "/interest-check">] InterestCheck

type Model =
    { Page: Page
      Modal: ModalImage
      Tutorial: TutorialModel }
