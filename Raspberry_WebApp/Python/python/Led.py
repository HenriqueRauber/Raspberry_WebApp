import sys
#IMPORTA A BIBLIOTECA PARA CONTROLAR GPIOS
import RPi.GPIO as gpio
#IMPORTA A BIBLIOTECA DE TEMPO
import time

#FUNCAO PARA DEFINIR O MODO DAS PORTAS 
def pinMode(porta, modo):
    gpio.setup(porta, modo)
        
#FUNCAO PARA LIGAR OU DESLIGAR AS PORTAS
def digilarWrite(porta, nivel):
    print("P:",porta," V:", nivel)
    gpio.output(porta, nivel)
        

def main(porta):
    #DEFINE PADRAO DE NUMERACAO DAS PORTAS
    gpio.setmode(gpio.BCM)
    #DEFINE A PORTA COMO SAIDA
    pinMode(porta, modo=gpio.OUT)
    #ENVIA SINAL ON PARA A PORTA
    digilarWrite(porta, nivel=gpio.HIGH)
    #ESPERA 3 SEGUNDOS
    time.sleep(3)
    #ENVIA SINAL OFF PARA A PORTA
    digilarWrite(porta, nivel=gpio.LOW)
    #lIMPA AS PORTAS (PARA O PRÓXIMO PROGRAMA COMEÇAR DO ZERO)
    gpio.cleanup()

#INICIO DA APLICACAO
if __name__ == '__main__':        
    #VERIFICA SE FOI PASSAO APENAS 1 ARGUMENTO.:(1 default + 1 informado = 2)
    if len(sys.argv) == 2:
        porta = -1
        try:
            #CONVERTE O ARGUMENTO EM UM INTEIRO
            porta = int(sys.argv[1])
        except Exception as e:
            print("Não foi possível idêntificar a porta informada! Erro:" + str(e))
            #SAI DO PROGRAMA
            exit()
        try:
            if (porta >= 0 and porta <= 27): 
                #EXECUTA O MÉTODO MAIN PASSANDO A PORTA
                main(porta)
            else:
                print("Porta inválida!")
        except Exception as e:
          print("Erro ao utilizar a porta " + porta + " Erro: " + str(e))
    else:
        print("Este programa deve ser iniciando com 1 argumento indicando a porta utilizada!")

#EXEMPLO:
#python3 Led.py 26
