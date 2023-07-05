export interface Empleados{
  id: string | null,
  nombres: string,
  apellidos: string,
  fechaNacimiento: string,
  fechaIngreso: string,
  fechaRetiro?: string | null,
  generoId: string,
  usuarioHabilitado: boolean,
  mail: string,
  cargo: string,
  areas: string,
  areasId: string,
  liderId: string
}

export interface EmpleadosCreateDto extends Omit<Empleados, 'id' | 'areas' | 'fechaRetiro'>{

}

export interface EmpleadoUpdateDto extends Omit<Empleados, 'areas'>{

}

export interface DDLEmpleados {
  id: string,
  nombres: string,
}
