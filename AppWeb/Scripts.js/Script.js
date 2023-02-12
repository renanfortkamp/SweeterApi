const corFundo = document.querySelector("#corFundo")
        const id = document.querySelector("#id")
        const conteudo = document.querySelector("#conteudo")
        const submit = document.querySelector("#submit")
        const conteudoSalvo = document.querySelector("#conteudo-salvo")

        submit.onclick = ()=>{
            
            const inputs = {
                "text": conteudo.value
            }
            
            fetch("https://192.168.0.2:7066/api/Sweets?userId="+ id.value,
            {
                method: 'POST',
                headers: {
                    'Content-Type': 'application/json',
                },
                body: JSON.stringify(inputs),
            }).then(()=>{
                atualizaFront()
            })
        }

       atualizaFront()
        

        function atualizaFront(){
            fetch("https://192.168.0.2:7066/api/Sweets")
            .then(e=>e.json())
            .then(data => {
                let html = ""
                
                data.forEach(element => {
                    html += `
                    <div class="Post">
                    <div>${element.text}</div>
                    <div>${element.userName}</div>
                    <div>${element.dataPostagem}</div>
                    </div>
                    `
                    
                });
                conteudoSalvo.innerHTML = html
            })
        }