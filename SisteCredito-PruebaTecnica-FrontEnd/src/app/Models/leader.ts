export interface Leader{
  id: string | null,
  nombres: string,
  apellidos: string,
  fechaNacimiento: string,
  fechaIngreso: string,
  generoId: string
  mail: string,
  cargo: string,
  areas: string,
  areasId: string
}

export interface LeaderDtoCreate extends Omit<Leader, 'id' | 'areas'>{

}

export interface LeaderDtoUpdate extends Omit<Leader, 'areas'>{

}
