import sqlite3
import pandas as pd
import glob
import os

conn = sqlite3.connect('ecommerce-order.db')
cursor = conn.cursor()

diretorio_csv = '../../docs/dataset'

arquivos_csv = glob.glob(os.path.join(diretorio_csv, '*.csv'))

for arquivo_csv in arquivos_csv:
    df = pd.read_csv(arquivo_csv)
    nome_tabela = os.path.splitext(os.path.basename(arquivo_csv))[0]
    df.to_sql(nome_tabela, conn, if_exists='replace', index=False)

conn.close()