open ImGuiNET.FSharp
open Elmish
open ImGuiNET

type Model = {
    ClickCount: int
}

type Msg = 
    | ButtonClicked

let init() = {
  ClickCount = 0
}

let update (msg: Msg) (model: Model) : Model =
    match msg with 
    | ButtonClicked -> { model with ClickCount = model.ClickCount + 1}

let view (model:Model) (dispatch:Msg -> unit) =     
    
    let flags = 
        //ImGuiWindowFlags.NoResize +
        ImGuiWindowFlags.NoMove +
        ImGuiWindowFlags.NoCollapse +
        //ImGuiWindowFlags.NoBackground +
        ImGuiWindowFlags.NoTitleBar +
        //ImGuiWindowFlags.NoDecoration +
        ImGuiWindowFlags.NoSavedSettings

    let gui =
        Gui.app [
            Gui.window "Demo" flags [                

                Gui.text "Here's a button. It's nice and shiny."

                Gui.button "+" (fun () -> ButtonClicked |> dispatch )

                Gui.sameLine [
                    Gui.text "It has been clicked."
                    Gui.text (model.ClickCount.ToString())
                    Gui.text "time(s)."
                ] |> Gui.alignText
            ]
        ]

    startOrUpdateGuiWith "Demo" gui |> ignore
    resizeGui( 300, 150)
    


Program.mkSimple init update view
|> Program.run