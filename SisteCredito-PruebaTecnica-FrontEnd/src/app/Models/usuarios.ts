export interface usuarios{
  id: string | null,
  nombres: string,
  apellidos: string,
  rol: string,
  email: string,
  userName: string,
  token: string,
  password: string
}

export interface usuariosLoginDto{
  email: string,
  password: string
}

export interface usuarioRegisterDto {
  nombres: string,
  apellidos: string,
  rol: string | null,
  email: string | null,
  userName: string | null,
  password: string | null
}
