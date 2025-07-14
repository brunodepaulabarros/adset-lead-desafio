import { Component, OnInit } from '@angular/core';
import { FormBuilder, FormGroup } from '@angular/forms';
import { Veiculo } from 'src/app/core/models/veiculo.model';

@Component({
  selector: 'app-list',
  templateUrl: './list.component.html',
  styleUrls: ['./list.component.scss']
})
export class ListComponent implements OnInit {
  filtroForm: FormGroup;
  veiculos: Veiculo[] = [];
  cores: string[] = ['Branco', 'Preto', 'Prata', 'Vermelho', 'Azul'];
  anos: number[] = [];
  pacotes: string[] = ['Básico', 'Bronze', 'Diamante', 'Platinum'];

  paginas = [1, 2, 3, 4, 5];
  paginaAtual = 1;

  constructor(private fb: FormBuilder) {
    this.filtroForm = this.fb.group({
      placa: [''],
      marca: [''],
      modelo: [''],
      anoMin: [''],
      anoMax: [''],
      preco: [''],
      fotos: [''],
      cor: ['']
    });
  }

  ngOnInit(): void {
    this.gerarAnos();
    this.carregarVeiculosMock();
  }

  gerarAnos(): void {
    const anoAtual = new Date().getFullYear();
    for (let ano = 2000; ano <= anoAtual; ano++) {
      this.anos.push(ano);
    }
  }

  carregarVeiculosMock(): void {
    this.veiculos = [
      {
        id: 1,
        marca: 'Volkswagen',
        modelo: 'Golf',
        ano: 2018,
        placa: 'AAA-0102',
        km: 25000,
        cor: 'Branco',
        preco: 103900,
        opcionais: ['Ar Condicionado', 'Airbag', 'Freio ABS'],
        fotos: ['https://via.placeholder.com/150'],
        pacotes: [
          { portal: 'iCarros', pacote: 'Diamante' },
          { portal: 'WebMotors', pacote: 'Básico' }
        ]
      },
      {
        id: 2,
        marca: 'Ford',
        modelo: 'Ka',
        ano: 2020,
        placa: 'BBB-2020',
        cor: 'Preto',
        preco: 53900,
        fotos: [],
        pacotes: [
          { portal: 'iCarros', pacote: 'Bronze' },
          { portal: 'WebMotors', pacote: 'Platinum' }
        ]
      }
    ];
  }

  getPacoteSelecionado(veiculo: Veiculo, portal: 'iCarros' | 'WebMotors'): string | undefined {
    return veiculo.pacotes?.find(p => p.portal === portal)?.pacote;
  }

  alterarPacote(veiculo: Veiculo, portal: 'iCarros' | 'WebMotors', novoPacote: string): void {
    if (!veiculo.pacotes) veiculo.pacotes = [];

    const index = veiculo.pacotes.findIndex(p => p.portal === portal);
    if (index > -1) {
      veiculo.pacotes[index].pacote = novoPacote as any;
    } else {
      veiculo.pacotes.push({ portal, pacote: novoPacote as any });
    }
  }

  buscar(): void {
    console.log('Filtros aplicados:', this.filtroForm.value);
  }

  editar(veiculo: Veiculo): void {
    console.log('Editar veículo:', veiculo);
  }

  deletar(id: number): void {
    if (confirm('Deseja excluir este veículo?')) {
      this.veiculos = this.veiculos.filter(v => v.id !== id);
    }
  }

  paginaAnterior(): void {
    if (this.paginaAtual > 1) this.paginaAtual--;
  }

  proximaPagina(): void {
    if (this.paginaAtual < this.paginas.length) this.paginaAtual++;
  }

  irParaPagina(p: number): void {
    this.paginaAtual = p;
  }
}
