module WaIIerKb.Client.Pages.AboutPage

open Bolero.Html

let titleText = "WaIIer Open Source Keyboards"

let mainText =
    "Each keyboard was designed from scratch, including a custom PCB and case. All the deisngs are open source and available on my Github. "
    + "These keyboards are not compatible with existing cases and are designed to be a more budget alternative to normally expensive custom "
    + "mechanical keyboards. If you want your own, you can order all the components yorself, or fill out the interest check if you would be "
    + "interested in a group buy or buying extras from me."

let bulletList =
    ul [ attr.``class`` "list-group"
         attr.style "width: 80ch" ] [
        li [ attr.``class`` "list-group-item" ] [
            text "All of this was inspeired by Github user "
            code [] [ text "ruiqimao" ]
            text "'s tutorial. "
            a [ attr.href "https://github.com/ruiqimao/keyboard-pcb-guide" ] [
                text " https://github.com/ruiqimao/keyboard-pcb-guide"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "QMK Firmware" ]
            text " Opensource mechanical keyboard firmware that powers most custom mechanical keyboards."
            a [ attr.href "https://docs.qmk.fm/#/" ] [
                text " https://docs.qmk.fm/#/"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "KiCad EDA" ]
            text " A Cross Platform and Open Source Electronics Design Automation Suite. Used to create the PCBs"
            a [ attr.href "https://kicad-pcb.org/" ] [
                text " https://kicad-pcb.org/"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "Product Design Online" ]
            text "'s Fusoin360 tutorials."
            a [ attr.href "https://www.youtube.com/watch?v=qvrHuaHhqHI" ] [
                text " https://www.youtube.com/watch?v=qvrHuaHhqHI"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "CruzCtrl" ]
            text " on Youtube for tutorials on cable sleeving and coiling (WIP)."
            a [ attr.href "https://www.youtube.com/watch?v=GCexLMPaNqo" ] [
                text " https://www.youtube.com/watch?v=GCexLMPaNqo"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "JLCPCB" ]
            text " for low cost PCB manufacturing."
            a [ attr.href "https://jlcpcb.com/" ] [
                text " https://jlcpcb.com/"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "Digikey" ]
            text " for electronic components."
            a [ attr.href " https://jlcpcb.com/" ] [
                text " https://jlcpcb.com/"
            ]
        ]
        li [ attr.``class`` "list-group-item" ] [
            code [] [ text "Bolero F#" ]
            text " WebAssembly library for "
            code [] [ text "F#" ]
            text "  that is used to make this website. It makes webdev a bit more bearable."
            a [ attr.href "https://fsbolero.io/" ] [
                text " https://fsbolero.io/"
            ]
        ]
    ]

let aboutPage model dispatch =
    div [] [
        h1 [] [ text titleText ]
        p [] [ text mainText ]
        h2 [] [
            text "Acknowledgements and Resources:"
        ]
        bulletList
    ]
