export interface Veiculo {
  id: number;
  marca: string;
  modelo: string;
  ano: number;
  placa: string;
  km?: number;
  cor: string;
  preco: number;
  opcionais?: string[];
  fotos?: string[];
  pacotes?: {
    portal: 'iCarros' | 'WebMotors';
    pacote: 'Básico' | 'Bronze' | 'Diamante' | 'Platinum';
  }[];
}
