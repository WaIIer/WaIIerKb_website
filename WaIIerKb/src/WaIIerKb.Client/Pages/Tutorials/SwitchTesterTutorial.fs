module WaIIerKb.Client.Pages.Tutorials.SwitchTesterTutorial

open Bolero.Html

open WaIIerKb.Client.Models.Message
open WaIIerKb.Client.Lib.Units
open WaIIerKb.Client.Models.Model
open WaIIerKb.Client.Pages.Tutorials.TutorialLib

let switchTesterTutorial =
    { Name = "Switch Tester Tutorial"
      Steps =
          [ { Id = 1
              Name = "Prepare Your Workspace"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 0<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      text "Prepare a clean workspace"
                      text "Skim through all the instructions before starting"
                      text "You will need the following:"
                      ul [] [
                          li [] [
                              text "Soldering iron and solder"
                          ]
                          li [] [ text "Flush cutters" ]
                          li [] [ text "Switch Tester PCB" ]
                          li [] [ text "Case and M2 screws" ]
                          li [] [
                              text "Cherry Mx compatible PCB mounted key switches (up to 9)"
                          ]
                          li [] [ text "5.1kΩ resistor (x2)" ]
                          li [] [
                              text "220 Ω resistor (1 per key switch)"
                          ]
                          li [] [ text "LED (1 per key switch)" ]
                          li [] [ text "USB C receptacle" ]
                          li [] [ text "Dip switch" ]
                          li [] [
                              text "Multimeter (reccomended)"
                          ]
                      ]
                  ] }
            { Id = 2
              Name = "Solder the 5.1 kΩ Resistors"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 3<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text "Prepare 2 5.1 kΩ resistors, the PCB, soldering iron, flush cutters, and solder"
                          ]
                          li [] [
                              text "Bend the leads on the resistor into a U-shape"
                          ]
                          li [] [
                              text "Insert the resistor into the holes for R10 and R11"
                              li [] [
                                  text "Direction does not matter"
                              ]
                          ]
                          li [] [
                              text "Bend the leads on the back side of the PCB so that the resistor stays in place"
                          ]
                          li [] [
                              text "Heat your soldering iron and tin the tip"
                          ]
                          li [] [
                              text
                                  "Place your iron on one side of a resistor lead, and the solder on the other until the lead is soldered in place"
                          ]
                          li [] [
                              text "Repeat for the other three leads"
                          ]
                          li [] [
                              text "Use the flush cutters to cut the extra lead"
                          ]
                      ]
                  ] }
            { Id = 3
              Name = "Solder the 220Ω Resistors"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 10<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text
                                  "Prepare 1 220 Ω resistor for each key switch you plan on using along with all the material from the previous step"
                          ]
                          li [] [
                              li [] [
                                  text "If you are not using 9 switches, decide which positions to populate:"
                                  ul [] [
                                      li [] [
                                          text "In the example I am using 5 switches in K1, K3, K5, K7, K9"
                                      ]
                                      li [] [
                                          text "Therefore, I populated R1, R3, R5, R7, and R9"
                                      ]
                                  ]
                              ]
                              li [] [
                                  text "Follow the instructions from the previous step"
                              ]
                          ]
                      ]
                  ] }
            { Id = 4
              Name = "Solder the Dip Switch"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 3<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text "Prepare the dip switch, and a piece of tape"
                          ]
                          li [] [
                              text """Place the switch in the PCB with the "On" label on the left side"""
                          ]
                          li [] [
                              text
                                  "Place a piece of tape on top of the switch so it does not move when flipped upside-down"
                          ]
                          li [] [
                              text "Solder in the leads of the switch"
                          ]
                          li [] [ text "Remove the tape" ]
                      ]
                  ] }
            { Id = 5
              Name = "Solder the USB C Receptacle"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 10<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text "Prepare the receptacle, and a piece of tape"
                          ]
                          li [] [
                              text "Place the receptacle on the PCB and use the tape to secure it in place"
                          ]
                          li [] [
                              text "Solder in the large pins on the outside"
                          ]
                          li [] [
                              text "Solder in the small pins"
                              ul [] [
                                  li [] [
                                      text "Put a little bit of solder on the tip of your iron"
                                  ]
                                  li [] [
                                      text "Starting with the top row, touch the pin until there is solder in the hole"
                                  ]
                                  li [] [
                                      text
                                          "If that is not working, and you have thin solder, you can touch the solder to the pin"
                                  ]
                              ]
                          ]
                          li [] [
                              text
                                  "If you have a multimeter, use continuity check mode to make sure no two adjacent pins are shorted"
                              ul [] [
                                  li [] [
                                      text "If there is a short, put your iron between the two pins"
                                  ]
                                  li [] [
                                      text
                                          "If there are several pins soldered together, drag your iron across the connected pins"
                                  ]
                              ]
                          ]
                      ]
                  ] }
            { Id = 6
              Name = "Solder the LEDs"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 5<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text "Prepare 1 led per switch, solder, and flush cutters"
                          ]
                          li [] [
                              text
                                  "With the longer lead to the left, place the LEDs in the same pattern as the keyswitches you plan on populating"
                          ]
                          li [] [
                              text "Bend the leads so the LEDs cannot move"
                          ]
                          li [] [
                              text "Solder in the leads and use the flush cutters to remove the excess lead"
                          ]
                      ]
                  ] }
            { Id = 7
              Name = "Solder in the Key Switches"
              YoutubeLink = "https://www.youtube.com/embed/NpEaa2P7qZI"
              TimeEstimate = 5<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [ text "Prepare the keyswitches" ]
                          li [] [
                              text "Place the switches in the PCB and push down until they cannot move"
                          ]
                          li [] [ text "Solder in the leads" ]
                      ]
                  ] }
            { Id = 8
              Name = "Finishing"
              YoutubeLink = "https://www.youtube.com/embed/VK9rOECjYvI"
              TimeEstimate = 5<minute>
              IsComplete = false
              HtmlText =
                  div [] [
                      ul [] [
                          li [] [
                              text "Place the PCB in the case and screw it in using M2 screws"
                          ]
                          li [] [
                              text "Place keycaps on the keys"
                          ]
                      ]
                  ] } ] }

let switchTesterTutorialPage model dispatch = generateTutorialHtml model dispatch
