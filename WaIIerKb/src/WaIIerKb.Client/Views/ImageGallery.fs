module WaIIerKb.Client.Views.ImageGallery

open System
open Bolero.Html

[<Measure>]
type px

type GalleryImage =
    { Source: string
      Caption: string
      AltText: string }

let private MAX_WIDTH = 400<px>
let private MAX_HEIGHT = 300<px>

let private _generateRow images =
    div
        [ attr.``class`` "row" ]
        (images
         |> Array.map (fun galleryImage ->
             div [ attr.``class``
                       ("thumbnail col-md-"
                        + (12 / images.Length).ToString()) ] [
                 a [ attr.href galleryImage.Source ] [
                     img [ attr.``class`` "img-thumbnail"
                           attr.src galleryImage.Source
                           attr.alt galleryImage.AltText
                           attr.style (sprintf "max-height: %dpx; max-width: %dpx" MAX_HEIGHT MAX_WIDTH) ]
                     div [ attr.``class`` "caption" ] [
                         text galleryImage.Caption
                     ]
                 ]
             ])
         |> Array.toList)

let private _generateGalleryHtml size (images: GalleryImage list) =
    images
    |> List.toSeq
    |> Seq.chunkBySize size
    |> Seq.map (fun rowImages -> _generateRow rowImages)
    |> Seq.toList



let imageGallery (images: GalleryImage list) =
    div [] (_generateGalleryHtml (Math.Min(images.Length, 2)) images)
